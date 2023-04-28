using ChatRealTime.Application.DTO.DTO;
using ChatRealTime.Domain.Models;

namespace ChatRealTime.Application.Interfaces
{
    public interface IRoomMapper
    {
        Room MapToRequest(RoomDTO room);
        RoomDTO MapToResponse(Room model);
        IEnumerable<RoomDTO> MapToResponse(IEnumerable<Room> model);
    }
}
