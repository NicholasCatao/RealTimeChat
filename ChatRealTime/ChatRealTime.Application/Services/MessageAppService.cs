using ChatRealTime.Application.DTO.DTO;
using ChatRealTime.Application.Interfaces;
using ChatRealTime.Domain.Core.Interfaces;
using ChatRealTime.Domain.Models;
using System.Text.RegularExpressions;

namespace ChatRealTime.Application.Services
{
    public class MessageAppService : IMessageAppService
    {
        private readonly IMessageService _messageService;
        private readonly IRoomService _roomService;
        private readonly IUserService _userService;
        private readonly IMessageMapper _messageMapper;

        public MessageAppService(IMessageService messageService, IMessageMapper messageMapper)
        {
            _messageService = messageService;
            _messageMapper = messageMapper;
        }

        public async Task<MessageDTO> CriarMessagemAsync(string usuarioNome, string sala, string conteudoMessagem )
        {
            var fromUser = await _userService.ObterUsuarioIdentityAsync(usuarioNome);
            var room = await _roomService.ObterSalaAsync(sala);

            var messagem = new Message()
            {
                Content = Regex.Replace(conteudoMessagem, @"<.*?>", string.Empty),
                FromUser = fromUser,
                ToRoom = room,
                Timestamp = DateTime.Now
            };

            await _messageService.IncluirMessagemAsync(messagem);

            return _messageMapper.MapToResponse(messagem);
        }

        public async Task IncluirMessagemAsync(Message message)
         => await _messageService.IncluirMessagemAsync(message);

        public async Task<MessageDTO> ObterMensagemAsync(int id)
         =>  _messageMapper.MapToResponse(await _messageService.ObterMensagemAsync(id));

        public async Task<IEnumerable<MessageDTO>> ObterMessagensSalaAsync(int idSala)
             => _messageMapper.MapToResponse(await _messageService.ObterMessagensSalaAsync(idSala));
    }
}
