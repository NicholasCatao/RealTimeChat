
using AutoMapper;
using ChatRealTime.Application.DTO.DTO;
using ChatRealTime.Application.Interfaces;
using ChatRealTime.Domain.Models;
using ChatRealTime.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
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
        private IMapper _mapper;

        public ChatHub(IUserAppService userAppService, IMessageAppService messageAppService, IMapper mapper)
        {
            _userAppService = userAppService;
            _messageAppService = messageAppService;
            _mapper = mapper;
        }

        public async Task EnviaMessagemaAsync(string receiverName, string message)
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
                        var messageViewModel = new MessageViewModel()
                        {
                            Content = Regex.Replace(message, @"<.*?>", string.Empty),
                            FromUserName = remetenteLogado.UserName,
                            FromFullName = remetenteLogado.FullName,
                            Avatar = remetenteLogado.Avatar,
                            Room = "",
                            Timestamp = DateTime.Now
                        };

                        var msg = new MessageModel
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

        public async Task DeixarChatRoomAsync(string roomName)
          => await Groups.RemoveFromGroupAsync(Context.ConnectionId, roomName);

        public async Task AderirChatRoomAsync(string roomName)
        {
            try
            {
                var user = _Connections.Where(u => u.UserName == IdentityName).FirstOrDefault();
                if (user != null && user.CurrentRoom != roomName)
                {
                    if (!string.IsNullOrEmpty(user.CurrentRoom))
                        await Clients.OthersInGroup(user.CurrentRoom).SendAsync("removeUser", user);

                    await DeixarChatRoomAsync(user.CurrentRoom);
                    await Groups.AddToGroupAsync(Context.ConnectionId, roomName);
                    user.CurrentRoom = roomName;

                    await Clients.OthersInGroup(roomName).SendAsync("addUser", user);
                }
            }
            catch (Exception ex)
            {
                await Clients.Caller.SendAsync("onError", "Falha ao aderir o chat!" + ex.Message);
            }
        }

        public IEnumerable<UserViewModel> ObterUsuarios(string roomName)
            => _Connections.Where(u => u.CurrentRoom == roomName).ToList();

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
        public override async Task OnConnectedAsync()
        {
            try
            {
                var user = await _userAppService.ObterUsuarioAsync(IdentityName);
                var userViewModel = _mapper.Map<AppUserModel, UserViewModel>(user);
                userViewModel.CurrentRoom = "";

                if (!_Connections.Any(u => u.UserName == IdentityName))
                {
                    _Connections.Add(userViewModel);
                    _ConnectionsMap.Add(IdentityName, Context.ConnectionId);
                }

                await Clients.Caller.SendAsync("getProfileInfo", userViewModel);
            }
            catch (Exception ex)
            {
                await Clients.Caller.SendAsync("onError", "OnConnected:" + ex.Message);
            }

            await base.OnConnectedAsync();
        }

        public override async Task OnDisconnectedAsync(Exception exception)
        {
            try
            {
                var user = _Connections.Where(u => u.UserName == IdentityName).First();
                _Connections.Remove(user);

                await Clients.OthersInGroup(user.CurrentRoom).SendAsync("removeUser", user);

                _ConnectionsMap.Remove(user.UserName);
            }
            catch (Exception ex)
            {
                await Clients.Caller.SendAsync("onError", "OnDisconnected: " + ex.Message);
            }

            await base.OnDisconnectedAsync(exception);
        }

        private string IdentityName { get { return Context.User.Identity.Name; } }
    }
}
