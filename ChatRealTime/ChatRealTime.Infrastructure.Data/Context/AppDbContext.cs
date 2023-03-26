using ChatRealTime.Domain.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Threading.Channels;

namespace ChatRealTime.Infrastructure.Data.Context
{
    public class AppDbContext : IdentityDbContext
    {
        private readonly string _ConnectionStringSqlServer;
        public AppDbContext(DbContextOptions<AppDbContext>options) : base(options)
        {
        }

        public AppDbContext()
        {
            
        }

           

        public DbSet<Message> Messages { get; set; }
        public DbSet<AppUser> AppUser { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            Console.WriteLine(Directory.GetCurrentDirectory());

            base.OnModelCreating(builder);
            builder.Entity<Message>()
                .HasOne<AppUser>(a => a.Sender)
                .WithMany(d => d.Messages)
                .HasForeignKey(d => d.Userid);
        }
    }
}
