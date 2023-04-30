using ChatRealTime.Domain.Models;

namespace ChatRealTime.Domain.Core.Interfaces
{
    public interface IRoomService
    {
        Task<Room> EditarSalaAsync(Room room);
        Task DeletarSalaAsync(Room room);
        Task<Room> ObterSalaAsync(int id, string adminRoom);
        Task<Room> IncluirSalaAsync(Room room);
        Task<Room> ObterSalaAsync(string charRoomName);
        Task<Room> ObterSalaPorIdAsync(int id);
        Task<IEnumerable<Room>> ObterSalasAsync();
    }
}
