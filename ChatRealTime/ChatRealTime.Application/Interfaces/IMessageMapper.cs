using ChatRealTime.Application.DTO.DTO;
using ChatRealTime.Domain.Models;

namespace ChatRealTime.Application.Interfaces
{
    public interface IMessageMapper
    {
        MessageDTO MapToResponse(Message model);
        IEnumerable<MessageDTO> MapToResponse(IEnumerable<Message> model);
    }
}
