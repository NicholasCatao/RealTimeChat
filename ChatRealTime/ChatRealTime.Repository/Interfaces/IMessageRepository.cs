using ChatRealTime.Domain.Models;

namespace ChatRealTime.Repository.Interfaces
{
    public interface IMessageRepository
    {
        Task IncluirMessagemAsync(Message message);
    }
}
