using ChatRealTime.Domain.Models;
using System.Security.Claims;

namespace ChatRealTime.Domain.Core.Interfaces
{
    public interface IUserService
    {
        Task<IEnumerable<Message>> GetAllMessageAsync();
        Task CreateMessageAsync(Message message);
    }
}
