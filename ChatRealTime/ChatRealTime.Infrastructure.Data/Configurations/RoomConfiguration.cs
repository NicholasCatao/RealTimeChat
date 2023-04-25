using ChatRealTime.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ChatRealTime.Infrastructure.Data.Configurations
{
    public class RoomConfiguration : IEntityTypeConfiguration<RoomModel>
    {
        public void Configure(EntityTypeBuilder<RoomModel> builder)
        {
            builder.ToTable("Rooms");

            builder.Property(s => s.Name).IsRequired().HasMaxLength(100);

            builder.HasOne(s => s.Admin)
                .WithMany(u => u.Rooms)
                .IsRequired();
        }
    }
}
