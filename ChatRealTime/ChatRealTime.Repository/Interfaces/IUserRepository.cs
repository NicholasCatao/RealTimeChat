using ChatRealTime.Domain.Models;

namespace ChatRealTime.Repository.Interfaces
{
    public interface IUserRepository
    {
        Task<AppUser> ObterUsuarioAsync(string id);
        Task<IEnumerable<AppUser>> ObterUsuariosAsync();
    }
}
