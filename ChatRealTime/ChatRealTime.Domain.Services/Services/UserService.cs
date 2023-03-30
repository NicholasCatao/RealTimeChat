using ChatRealTime.Domain.Core.Interfaces;
using ChatRealTime.Domain.Models;
using ChatRealTime.Repository.Interfaces;
using System.Security.Claims;

namespace ChatRealTime.Domain.Services.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<IEnumerable<Message>> GetAllMessageAsync()
            => await _userRepository.GetAllMessageAsync();

        public async Task CreateMessageAsync(Message message)
        {
          await  _userRepository.CreateMessageAsync(message);
        }

    }
}
