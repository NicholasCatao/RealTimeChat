using ChatRealTime.Domain.Models;

namespace ChatRealTime.Domain.Core.Interfaces
{
    public interface IUserService
    {
        Task<AppUserModel> ObterUsuarioAsync(string id);
        Task<IEnumerable<AppUserModel>> ObterUsuariosAsync();
    }
}
