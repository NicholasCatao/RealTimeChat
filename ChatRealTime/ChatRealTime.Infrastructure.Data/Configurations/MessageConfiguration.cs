using ChatRealTime.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ChatRealTime.Infrastructure.Data.Configurations
{
    public class MessageConfiguration : IEntityTypeConfiguration<MessageModel>
    {
        public void Configure(EntityTypeBuilder<MessageModel> builder)
        {
            builder.ToTable("Messages");

            builder.Property(s => s.Content).IsRequired().HasMaxLength(500);

            builder.HasOne(s => s.ToRoom)
                .WithMany(m => m.Messages)
                .HasForeignKey(s => s.ToRoomId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
