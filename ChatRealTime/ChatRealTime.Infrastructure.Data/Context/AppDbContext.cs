using ChatRealTime.Domain.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace ChatRealTime.Infrastructure.Data.Context
{
    public class AppDbContext : IdentityDbContext<AppUserModel>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
        {
        }

        public DbSet<RoomModel> Rooms { get; set; }
        public DbSet<MessageModel> Messages { get; set; }
        public DbSet<AppUserModel> AppUsers { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<AppUserModel>()
            .HasMany(u => u.Messages)
            .WithOne(m => m.FromUser)
            .HasForeignKey(m => m.FromUserId)
            .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
