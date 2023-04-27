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

        public async Task<AppUser> ObterUsuarioAsync(string id)
             => await _userRepository.ObterUsuarioAsync(id);

        public async Task<AppUser> ObterUsuarioIdentityAsync(string nome)
             => await _userRepository.ObterUsuarioAsync(nome);

        public async Task<IEnumerable<AppUser>> ObterUsuariosAsync()
            => await _userRepository.ObterUsuariosAsync();

    }
}
