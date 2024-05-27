using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Tomnaia.Entities;

namespace Tomnaia.Data.Configuration
{
    public class NotificationEntityTypeConfiguration : IEntityTypeConfiguration<Notification>
    {
        public void Configure(EntityTypeBuilder<Notification> builder)
        {
            builder
                .HasOne(c => c.Receiver)
                .WithMany(u => u.Notifications)
                .HasForeignKey(c => c.ReceiverId)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
