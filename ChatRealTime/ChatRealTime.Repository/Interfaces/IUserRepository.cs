using ChatRealTime.Domain.Models;

namespace ChatRealTime.Repository.Interfaces
{
    public interface IUserRepository
    {
        Task<AppUserModel> ObterUsuarioAsync(string id);
        Task<IEnumerable<AppUserModel>> ObterUsuariosAsync();
    }
}
