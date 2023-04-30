using ChatRealTime.Application.DTO.DTO;
using ChatRealTime.Domain.Models;

namespace ChatRealTime.Application.Interfaces
{
    public interface IRoomAppService
    {
        Task<RoomDTO> ObterSalaAsync(int id, string adminRoom);
        Task<Room> IncluirSalaAsync(RoomDTO roomRequest, string identityName);
        Task<RoomDTO> ObterSalaAsync(string chatRoomName);
        Task<RoomDTO> ObterSalaPorIdAsync(int id);
        Task<IEnumerable<RoomDTO>> ObterSalasAsync();
        Task<(int, string)> DeletarSalaAsync(int id, string adminRoom);
        Task<Room> EditarSalaAsync(int id, RoomDTO roomRequest, string identityName);
    }

}
