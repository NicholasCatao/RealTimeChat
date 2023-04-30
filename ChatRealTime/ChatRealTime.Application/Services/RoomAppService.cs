using ChatRealTime.Application.DTO.DTO;
using ChatRealTime.Application.Interfaces;
using ChatRealTime.Domain.Core.Interfaces;
using ChatRealTime.Domain.Models;

namespace ChatRealTime.Application.Services
{
    public class RoomAppService : IRoomAppService
    {
        private readonly IRoomService _roomService;
        private readonly IUserService _userService;
        private readonly IRoomMapper _roomMapper;

        public RoomAppService(IRoomService roomService, IUserService userService, IRoomMapper roomMapper)
        {
            _roomService = roomService;
            _userService = userService;
            _roomMapper = roomMapper;
        }

        public async Task<Room> IncluirSalaAsync(RoomDTO roomRequest, string identityName)
        {
            var user = await _userService.ObterUsuarioIdentityAsync(identityName);

            var room = new Room()
            {
                Name = roomRequest.Name,
                Admin = user
            };

            return await _roomService.IncluirSalaAsync(room);
        }

        public async Task<Room> EditarSalaAsync(int id, RoomDTO roomRequest, string identityName)
        {
            var user = await _userService.ObterUsuarioIdentityAsync(identityName);

            var room = new Room()
            {
                Name = roomRequest.Name,
                Admin = user
            };

           return await _roomService.EditarSalaAsync(room);
        }

        public async Task<(int, string)> DeletarSalaAsync(int id, string adminRoom)
        {
            var room = await _roomService.ObterSalaAsync(id, adminRoom);
            await _roomService.DeletarSalaAsync(room);

            return new (room.Id, room.Name);
        }

        public async Task<RoomDTO> ObterSalaAsync(int id, string adminRoom)
              => _roomMapper.MapToResponse(await _roomService.ObterSalaAsync(id, adminRoom));

        public async Task<RoomDTO> ObterSalaAsync(string chatRoomName)
            => _roomMapper.MapToResponse(await _roomService.ObterSalaAsync(chatRoomName));

        public async Task<RoomDTO> ObterSalaPorIdAsync(int id)
           => _roomMapper.MapToResponse(await _roomService.ObterSalaPorIdAsync(id));

        public async Task<IEnumerable<RoomDTO>> ObterSalasAsync()
             => _roomMapper.MapToResponse(await _roomService.ObterSalasAsync());
    }
}
