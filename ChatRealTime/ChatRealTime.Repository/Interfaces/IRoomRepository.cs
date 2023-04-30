using ChatRealTime.Domain.Models;

namespace ChatRealTime.Repository.Interfaces
{
    public interface IRoomRepository
    {
        Task IncluirSalaAsync(Room room);
        Task<Room> EditarSalaAsync(Room room);
        Task DeletarSalaAsync(Room room);
        Task<Room> ObterSalaAsync(int idRoom, string adminRoom);
        Task<Room> ObterSalaAsync(string chatRoom);
        Task<Room> ObterSalaPorIdAsync(int id);
        Task<IEnumerable<Room>> ObterSalasAsync();
    }
}
