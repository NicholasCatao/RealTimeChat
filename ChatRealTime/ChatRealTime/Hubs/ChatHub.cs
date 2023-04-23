
using ChatRealTime.Application.Interfaces;
using ChatRealTime.Domain.Models;
using ChatRealTime.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.SignalR;
using System.Text.RegularExpressions;

namespace ChatRealTime.Hubs
{
    [Authorize]
    public class ChatHub : Hub
    {
        public readonly static List<UserViewModel> _Connections = new List<UserViewModel>();
        private readonly static Dictionary<string, string> _ConnectionsMap = new Dictionary<string, string>();


        private readonly IUserAppService _userAppService;
        private readonly IMessageAppService _messageAppService;


        public async Task EnviaMessagem(string receiverName, string message)
        {
            try
            {
                if (_ConnectionsMap.TryGetValue(receiverName, out string userId))
                {
                    var remetenteLogado = _Connections.Where(u => u.UserName == IdentityName).First();

                    var remetente = await _userAppService.ObterUsuarioAsync(remetenteLogado.Id);
                    var destinatario = await _userAppService.ObterUsuarioAsync(remetenteLogado.Id);

                    if (!string.IsNullOrEmpty(message.Trim()))
                    {
                       
                        //Todo Encapsular uma tupla talves
                        var messageViewModel = new MessageViewModel()
                        {
                            Content = Regex.Replace(message, @"<.*?>", string.Empty),
                            FromUserName = remetenteLogado.UserName,
                            FromFullName = remetenteLogado.FullName,
                            Avatar = remetenteLogado.Avatar,
                            Room = "",
                            Timestamp = DateTime.Now
                        };

                        var msg = new Message
                        {
                            Content = Regex.Replace(message, @"<.*?>", string.Empty),
                            FromUserId = remetente.Id,
                            ToUserId = destinatario.Id,
                            Timestamp = DateTime.Now
                        };


                        await _messageAppService.IncluirMessagemAsync(msg);

                        await Clients.Client(userId).SendAsync("newMessage", messageViewModel);
                        await Clients.Caller.SendAsync("newMessage", messageViewModel);
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        

        public async Task Leave(string roomName)
        {
            await Groups.RemoveFromGroupAsync(Context.ConnectionId, roomName);
        }

        public IEnumerable<UserViewModel> ObterUsuarios(string roomName)
        {
            return _Connections.Where(u => u.CurrentRoom == roomName).ToList();
        }

        public async Task<IEnumerable<UserViewModel>> ObterUsuariosRegistradosAsync()
        {
            var users = await _userAppService.ObterUsuariosAsync();

            var userViewModel = users.Select(user => new UserViewModel
            {
                Id = user.Id,
                Avatar = user.Avatar,
                UserName = user.UserName,
                FullName = user.FullName,
                Status = _Connections.Exists(x => x.Id == user.Id) ? "Verde" : "Preto",
            }).ToList();

            return userViewModel;
        }


        private string IdentityName
        {
            get { return Context.User.Identity.Name; }
        }

    }
}
