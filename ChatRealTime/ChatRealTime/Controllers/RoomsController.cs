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

            var room = await _context.Rooms
                .Include(r => r.Admin)
                .Where(r => r.Id == id && r.Admin.UserName == User.Identity.Name)
                .FirstOrDefaultAsync();

            if (room == null)
                return NotFound();

            room.Name = roomRequest.Name;
            await roomRequest.SaveChangesAsync();

            var updatedRoom = _mapper.Map<Room, RoomViewModel>(room);
            await _hubContext.Clients.All.SendAsync("updateChatRoom", updatedRoom);

            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var room = await _context.Rooms
                .Include(r => r.Admin)
                .Where(r => r.Id == id && r.Admin.UserName == User.Identity.Name)
                .FirstOrDefaultAsync();

            if (room == null)
                return NotFound();

            _context.Rooms.Remove(room);
            await _context.SaveChangesAsync();

            await _hubContext.Clients.All.SendAsync("removeChatRoom", room.Id);
            await _hubContext.Clients.Group(room.Name).SendAsync("onRoomDeleted");

            return Ok();
        }
    }
}
