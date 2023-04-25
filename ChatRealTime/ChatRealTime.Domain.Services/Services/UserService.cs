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

      

        public async Task<AppUserModel> ObterUsuarioAsync(string id)
             => await _userRepository.ObterUsuarioAsync(id);

        public async Task<IEnumerable<AppUserModel>> ObterUsuariosAsync()
            => await _userRepository.ObterUsuariosAsync();

    }
}
