using ChatRealTime.Application.Interfaces;
using ChatRealTime.Domain.Core.Interfaces;
using ChatRealTime.Domain.Models;
using System.Security.Claims;

namespace ChatRealTime.Application.Services
{

    public class UserAppService : IUserAppService
    {
        private readonly IUserService _userService;

        public UserAppService(IUserService userService)
        {
            _userService = userService;
        }

        public async Task<IEnumerable<Message>> GetAllMessageAsync()
           => await _userService.GetAllMessageAsync();

        public async Task CreateMessageAsync(Message  message)
        {
            await _userService.CreateMessageAsync(message);
        }

    }
}
