using ChatRealTime.Domain.Core.Interfaces;
using ChatRealTime.Domain.Models;
using ChatRealTime.Repository.Interfaces;

namespace ChatRealTime.Domain.Services.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        //public async Task<IEnumerable<Message>> GetAllMessageAsync()
        //    => await _userRepository.GetAllMessageAsync();

        //public async Task CreateMessageAsync(Message message)
        //{
        //  await  _userRepository.CreateMessageAsync(message);
        //}

        public async Task<AppUser> ObterUsuarioAsync(string id)
             => await _userRepository.ObterUsuarioAsync(id);

        public async Task<IEnumerable<AppUser>> ObterUsuariosAsync()
            => await _userRepository.ObterUsuariosAsync();

    }
}
