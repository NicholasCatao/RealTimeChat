using ChatRealTime.Domain.Models;
using System.Security.Claims;

namespace ChatRealTime.Application.Interfaces
{
    public interface IUserAppService
    {
        Task<IEnumerable<Message>> GetAllMessageAsync();
        Task CreateMessageAsync(Message message);
    }
}
