using ChatRealTime.Domain.Models;
using System.Security.Claims;

namespace ChatRealTime.Repository.Interfaces
{
    public interface IUserRepository
    {
        Task<IEnumerable<Message>> GetAllMessageAsync();
        Task CreateMessageAsync(Message message);
    }
}
