using ChatRealTime.Domain.Models;

namespace ChatRealTime.Domain.Core.Interfaces
{
    public interface IMessageService
    {
       // Task<IEnumerable<Message>> GetAllMessageAsync();
        Task IncluirMessagemAsync(Message message);
    }
}
