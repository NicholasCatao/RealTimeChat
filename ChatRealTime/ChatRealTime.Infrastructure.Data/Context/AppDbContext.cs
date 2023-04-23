using ChatRealTime.Domain.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace ChatRealTime.Infrastructure.Data.Context
{
    public class AppDbContext : IdentityDbContext<AppUser>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
        {
        }

        public DbSet<Room> Rooms { get; set; }
        public DbSet<Message> Messages { get; set; }
        public DbSet<AppUser> AppUsers { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<AppUser>()
            .HasMany(u => u.Messages)
            .WithOne(m => m.FromUser)
            .HasForeignKey(m => m.FromUserId)
            .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
