using AutoMapper.Internal;
using ChatRealTime.Application.DTO.DTO;
using ChatRealTime.Application.Interfaces;
using ChatRealTime.Application.Mappers;
using ChatRealTime.Domain.Core.Interfaces;
using ChatRealTime.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System.Xml.Linq;

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

        public async Task<Room> IncluirSalaAsync( RoomDTO roomRequest, string identityName)
        {
            var user = await _userService.ObterUsuarioIdentityAsync(identityName);

            var room = new Room()
            {
                Name = roomRequest.Name,
                Admin = user
            };

            return await _roomService.IncluirSalaAsync(room);
        }

        public async Task<RoomDTO> ObterSalaAsync(string chatRoomName)
            => _roomMapper.MapToResponse(await _roomService.ObterSalaAsync(chatRoomName));

        public async Task<RoomDTO> ObterSalaPorIdAsync(int id)
           => _roomMapper.MapToResponse(await _roomService.ObterSalaPorIdAsync(id));

        public async Task<IEnumerable<RoomDTO>> ObterSalasAsync()
             => _roomMapper.MapToResponse(await _roomService.ObterSalasAsync());
    }
}
