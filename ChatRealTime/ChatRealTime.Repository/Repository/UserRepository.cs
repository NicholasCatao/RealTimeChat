using ChatRealTime.Domain.Models;
using ChatRealTime.Infrastructure.Data.Context;
using ChatRealTime.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace ChatRealTime.Repository.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly AppDbContext _appDbContext;

        public UserRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task<IEnumerable<Message>> GetAllMessageAsync()
        {
          return await _appDbContext.Messages.ToListAsync();
        }

        public async Task CreateMessageAsync(Message message)
        {
            await _appDbContext.Messages.AddAsync(message);
            await _appDbContext.SaveChangesAsync();
        }
    }
}
