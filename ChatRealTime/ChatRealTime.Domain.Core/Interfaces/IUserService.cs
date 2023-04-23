using ChatRealTime.Domain.Models;

namespace ChatRealTime.Domain.Core.Interfaces
{
    public interface IUserService
    {
        Task<AppUser> ObterUsuarioAsync(string id);
        Task<IEnumerable<AppUser>> ObterUsuariosAsync();
    }
}
