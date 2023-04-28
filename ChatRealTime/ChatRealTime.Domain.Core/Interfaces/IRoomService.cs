using ChatRealTime.Domain.Models;

namespace ChatRealTime.Domain.Core.Interfaces
{
    public interface IRoomService
    {
        Task<Room> IncluirSalaAsync(Room room);
        Task<Room> ObterSalaAsync(string charRoomName);
        Task<Room> ObterSalaPorIdAsync(int id);
        Task<IEnumerable<Room>> ObterSalasAsync();
    }
}
