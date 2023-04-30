using AutoMapper;
using ChatRealTime.Application.DTO.DTO;
using ChatRealTime.Application.Interfaces;
using ChatRealTime.Domain.Models;
using ChatRealTime.Hubs;
using ChatRealTime.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;

namespace ChatRealTime.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class RoomsController : ControllerBase
    {
        private readonly IHubContext<ChatHub> _hubContext;
        private readonly IRoomAppService _roomAppService;
        private readonly IMapper _mapper;
        public RoomsController(IHubContext<ChatHub> hubContext) => _hubContext = hubContext;

        [HttpGet]
        public async Task<ActionResult<IEnumerable<RoomDTO>>> GetRoomsListAsync()
            => Ok(await _roomAppService.ObterSalasAsync());

        [HttpGet("{id}")]
        public async Task<ActionResult<RoomDTO>> Get(int id)
        {
            var room = await _roomAppService.ObterSalaPorIdAsync(id);

            if (room == null) return NotFound();

            return Ok(room);
        }

        [HttpPost]
        public async Task<ActionResult<RoomDTO>> Create(RoomDTO roomrequest)
        {
            //if (_context.Rooms.Any(r => r.Name == viewModel.Name))
            //    return BadRequest("Invalid room name or room already exists");

            var room = await _roomAppService.IncluirSalaAsync(roomrequest, User.Identity.Name);

            await _hubContext.Clients.All.SendAsync("addChatRoom", room);

            return CreatedAtAction(nameof(Get), new { id = room.Id }, room);

        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Edit(int id, RoomDTO roomRequest)
        {
            //if (_context.Rooms.Any(r => r.Name == viewModel.Name))
            //    return BadRequest("Invalid room name or room already exists");

            var room = await _roomAppService.EditarSalaAsync(id, roomRequest, User.Identity.Name);

            if (room == null) return NotFound();

            await _hubContext.Clients.All.SendAsync("updateChatRoom", room);

            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var room = await _roomAppService.DeletarSalaAsync(id, User.Identity.Name);

            await _hubContext.Clients.All.SendAsync("removeChatRoom", room.Item1) ;
            await _hubContext.Clients.Group(room.Item2).SendAsync("onRoomDeleted");

            return Ok();
        }
    }
}
