using ChatRealTime.Domain.Models;
using ChatRealTime.Infrastructure.Data.Context;
using ChatRealTime.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ChatRealTime.Repository.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly AppDbContext _appDbContext;

        public UserRepository(AppDbContext appDbContext) => _appDbContext = appDbContext;

        public async Task<AppUserModel> ObterUsuarioAsync(string id)
           =>  await _appDbContext.Users.FirstOrDefaultAsync(u => u.Id == id);

        public async Task<IEnumerable<AppUserModel>> ObterUsuariosAsync()
         => await _appDbContext.Users.ToListAsync();
    }
}
