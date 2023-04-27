using ChatRealTime.Domain.Models;

namespace ChatRealTime.Application.Interfaces
{
    public interface IUserAppService
    {
        Task<AppUser> ObterUsuarioAsync(string id);
        Task<AppUser> ObterUsuarioIdentityAsync(string nome);
        Task<IEnumerable<AppUser>> ObterUsuariosAsync();
    }
}
