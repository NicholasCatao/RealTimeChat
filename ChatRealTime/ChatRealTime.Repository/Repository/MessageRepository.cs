using ChatRealTime.Domain.Models;
using ChatRealTime.Infrastructure.Data.Context;
using ChatRealTime.Repository.Interfaces;

namespace ChatRealTime.Repository.Repository
{
    public class MessageRepository : IMessageRepository
    {
        private readonly AppDbContext _appDbContext;

        public MessageRepository(AppDbContext appDbContext) => _appDbContext = appDbContext;

        public async Task IncluirMessagemAsync(Message message)
        {
            await _appDbContext.Messages.AddAsync(message);
            await _appDbContext.SaveChangesAsync();
        }
    }
}
