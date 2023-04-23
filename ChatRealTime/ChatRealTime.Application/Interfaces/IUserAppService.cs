using ChatRealTime.Domain.Models;

namespace ChatRealTime.Application.Interfaces
{
    public interface IUserAppService
    {
        Task<AppUser> ObterUsuarioAsync(string id);
        Task<IEnumerable<AppUser>> ObterUsuariosAsync();
    }
}
