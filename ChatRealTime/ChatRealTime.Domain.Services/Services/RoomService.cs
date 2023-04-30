using ChatRealTime.Domain.Core.Interfaces;
using ChatRealTime.Domain.Models;
using ChatRealTime.Repository.Interfaces;

namespace ChatRealTime.Domain.Services.Services
{
    public class RoomService : IRoomService
    {
        private readonly IRoomRepository _roomRepository;
        public RoomService(IRoomRepository roomRepository) => _roomRepository = roomRepository;

        public async Task<Room> IncluirSalaAsync(Room room)
        {
            await _roomRepository.IncluirSalaAsync(room);
            return room;
        }

        public async Task<Room> EditarSalaAsync(Room room)
         =>  await _roomRepository.EditarSalaAsync(room);

        public async Task  DeletarSalaAsync(Room room)
             => await _roomRepository.DeletarSalaAsync(room);

        public async Task<Room> ObterSalaAsync(int id, string adminRoom)
            => await _roomRepository.ObterSalaAsync(id, adminRoom);

        public async Task<Room> ObterSalaAsync(string charRoomName)
            => await _roomRepository.ObterSalaAsync(charRoomName);

        public async Task<Room> ObterSalaPorIdAsync(int id)
         => await _roomRepository.ObterSalaPorIdAsync(id);

        public async Task<IEnumerable<Room>> ObterSalasAsync()
              => await _roomRepository.ObterSalasAsync();
    }
}
