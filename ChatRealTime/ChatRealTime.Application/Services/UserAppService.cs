using ChatRealTime.Application.Interfaces;
using ChatRealTime.Domain.Core.Interfaces;
using ChatRealTime.Domain.Models;

namespace ChatRealTime.Application.Services
{

    public class UserAppService : IUserAppService
    {
        private readonly IUserService _userService;

        public UserAppService(IUserService userService)
        {
            _userService = userService;
        }

        public async Task<AppUser> ObterUsuarioAsync(string id)
        {
            return await _userService.ObterUsuarioAsync(id);

            //Todo Adicionar Mapper de AppUser para AppUserDTO
        }

        public async Task<IEnumerable<AppUser>> ObterUsuariosAsync()
          => await _userService.ObterUsuariosAsync();
    }
}
