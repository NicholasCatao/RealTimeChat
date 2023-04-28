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

        public async Task<AppUser> ObterUsuarioAsync(string id)
           => await _appDbContext.Users.AsNoTracking().FirstOrDefaultAsync(u => u.Id == id);

        public async Task<AppUser> ObterUsuarioIdentityAsync(string nome)
          => await _appDbContext.Users.AsNoTracking().FirstOrDefaultAsync(u => u.UserName == nome);

        public async Task<IEnumerable<AppUser>> ObterUsuariosAsync()
         => await _appDbContext.Users.ToListAsync();


    }
}
