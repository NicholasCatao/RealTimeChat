using ChatRealTime.Domain.Models;

namespace ChatRealTime.Domain.Core.Interfaces
{
    public interface IUserService
    {
        Task<AppUser> ObterUsuarioAsync(string id);
        Task<AppUser> ObterUsuarioIdentityAsync(string nome);
        Task<IEnumerable<AppUser>> ObterUsuariosAsync();
    }
}
