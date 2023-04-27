using ChatRealTime.Domain.Models;

namespace ChatRealTime.Repository.Interfaces
{
    public interface IRoomRepository
    {
        Task IncluirSalaAsync(Room room);
        Task<Room> ObterSalaAsync(string chatRoom);
        Task<Room> ObterSalaPorIdAsync(int id);
        Task<IEnumerable<Room>> ObterSalasAsync();
    }
}
