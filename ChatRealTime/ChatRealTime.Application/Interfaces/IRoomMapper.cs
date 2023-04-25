using ChatRealTime.Application.DTO.DTO;
using ChatRealTime.Domain.Models;

namespace ChatRealTime.Application.Interfaces
{
    public interface IRoomMapper
    {
        RoomDTO MapToResponse(RoomModel model);
    }
}
