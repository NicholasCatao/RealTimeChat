using ChatRealTime.Domain.Models;
using ChatRealTime.Infrastructure.Data.Context;
using ChatRealTime.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ChatRealTime.Repository.Repository
{
    public class RoomRepository : IRoomRepository
    {
        private readonly AppDbContext _appDbContext;

        public RoomRepository(AppDbContext appDbContext) => _appDbContext = appDbContext;

        public async Task IncluirSalaAsync(Room room)
        {
            await _appDbContext.Rooms.AddAsync(room);
            await _appDbContext.SaveChangesAsync();
        }

        public async Task<Room> ObterSalaAsync(int idRoom, string adminRoom)
             => await _appDbContext.Rooms
               .Include(r => r.Admin)
               .AsNoTracking()
               .Where(r => r.Id == idRoom && r.Admin.UserName == adminRoom)
               .FirstOrDefaultAsync();


        public async Task<Room> ObterSalaAsync(string chatRoom)
          => await _appDbContext.Rooms.AsNoTracking().FirstOrDefaultAsync(x => x.Name == chatRoom);

        public async Task<Room> ObterSalaPorIdAsync(int id)
        => await _appDbContext.Rooms.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);

        public async Task<IEnumerable<Room>> ObterSalasAsync()
            => await _appDbContext.Rooms
                .Include(r => r.Admin)
                .AsNoTracking()
                .ToListAsync();

        public async Task<Room> EditarSalaAsync(Room room)
        {
            _appDbContext.Rooms.Update(room);
            await _appDbContext.SaveChangesAsync();

            return _appDbContext.Rooms.First(e => e.Id == room.Id);
        }

        public async Task DeletarSalaAsync(Room room)
        {
            _appDbContext.Remove(room);
            await _appDbContext.SaveChangesAsync();
        }

    }
}

