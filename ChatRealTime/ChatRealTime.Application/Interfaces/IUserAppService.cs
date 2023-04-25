using ChatRealTime.Domain.Models;

namespace ChatRealTime.Application.Interfaces
{
    public interface IUserAppService
    {
        Task<AppUserModel> ObterUsuarioAsync(string id);
        Task<IEnumerable<AppUserModel>> ObterUsuariosAsync();
    }
}
