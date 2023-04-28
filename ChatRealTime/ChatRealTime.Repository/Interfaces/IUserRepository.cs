using ChatRealTime.Domain.Models;

namespace ChatRealTime.Repository.Interfaces
{
    public interface IUserRepository
    {
        Task<AppUser> ObterUsuarioAsync(string id);
        Task<AppUser> ObterUsuarioIdentityAsync(string nome);
        Task<IEnumerable<AppUser>> ObterUsuariosAsync();
    }
}
