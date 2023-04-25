using ChatRealTime.Application.DTO.DTO;
using ChatRealTime.Domain.Models;

namespace ChatRealTime.Application.Interfaces
{
    public interface IMessageMapper
    {
        MessageDTO MapToResponse(MessageModel model);
    }
}
