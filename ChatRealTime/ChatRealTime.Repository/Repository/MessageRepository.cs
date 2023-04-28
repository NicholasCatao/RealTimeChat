using ChatRealTime.Domain.Models;
using ChatRealTime.Infrastructure.Data.Context;
using ChatRealTime.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

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

        public async Task<Message> ObterMensagemAsync(int id)
           =>  _appDbContext.Messages.AsNoTracking().FirstOrDefault(x => x.Id == id);

        public async Task<IEnumerable<Message>> ObterMessagensSalaAsync(int idSala)
           => _appDbContext.Messages.Where(m => m.ToRoomId == idSala)
                .Include(m => m.FromUser)
                .Include(m => m.ToRoom)
                .OrderByDescending(m => m.Timestamp)
                .Take(20)
                .AsEnumerable()
                .Reverse()
                .ToList();
    }
}

