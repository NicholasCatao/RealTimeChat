using AutoMapper;
using ChatRealTime.Application.DTO.DTO;
using ChatRealTime.Application.Interfaces;
using ChatRealTime.Hubs;
using ChatRealTime.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;

namespace Chat.Web.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class MessagesController : ControllerBase
    {
        private readonly IMessageAppService _messageAppService;
        private readonly IRoomAppService _roomAppService;
        private readonly IMapper _mapper;
        private readonly IHubContext<ChatHub> _hubContext;

        public MessagesController(IMessageAppService messageAppService,
           IRoomAppService roomAppService, IMapper mapper, IHubContext<ChatHub> hubContext)
        {
            _messageAppService = messageAppService;
            _roomAppService = roomAppService;
            _mapper = mapper;
            _hubContext = hubContext;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<RoomViewModel>> Get(int id)
        {
            var message = await _messageAppService.ObterMensagemAsync(id);

            if (message == null) return NotFound();

            return Ok(message);
        }

        [HttpGet("Room/{roomName}")]
        public async Task<IActionResult> GetMessages(string roomName)
        {
            var sala = await _roomAppService.ObterSalaAsync(roomName);

            if (sala == null) return BadRequest();

            var messages = _messageAppService.ObterMessagensSalaAsync(sala.Id);

            return Ok(messages);
        }

        [HttpPost]
        public async Task<ActionResult<MessageViewModel>> Create(MessageDTO message)
        {
            var messagem = await _messageAppService.CriarMessagemAsync(message.FromUserName, message.Room, message.Content);

            var createdMessage = _mapper.Map<MessageDTO, MessageViewModel>(messagem);
            await _hubContext.Clients.Group(messagem.Room).SendAsync("newMessage", createdMessage);

            return CreatedAtAction(nameof(Get), new { id = messagem.Id }, createdMessage);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var message = await _messageAppService.ObterMensagemAsync(id);

            if (message == null) return NotFound();

            await _hubContext.Clients.All.SendAsync("removeChatMessage", message.Id);

            return Ok();
        }
    }
}
