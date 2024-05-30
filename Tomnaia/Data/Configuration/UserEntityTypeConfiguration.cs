using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Tomnaia.Entities;

namespace Tomnaia.Data.Configuration
{
    public class UserEntityTypeConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {



            //builder
            //    .HasMany(c => c.Comments)
            //    .WithOne(u => u.User)
            //    .HasForeignKey(c => c.UserId)
            //    .OnDelete(DeleteBehavior.Cascade);



            //builder
            //    .HasMany(c => c.ReceivedRates)
            //    .WithOne(u => u.Rated)
            //    .HasForeignKey(c => c.RatedId)
            //    .OnDelete(DeleteBehavior.Cascade);



            //builder
            //    .HasMany(c => c.Notifications)
            //    .WithOne(u => u.Receiver)
            //    .HasForeignKey(c => c.ReceiverId)
            //    .OnDelete(DeleteBehavior.Cascade);

            //builder
            //    .HasMany(c => c.SentMessages)
            //    .WithOne(u => u.Sender)
            //    .HasForeignKey(c => c.SenderId)
            //    .OnDelete(DeleteBehavior.Cascade);

            //builder
            //    .HasMany(c => c.ReceivedMessages)
            //    .WithOne(u => u.Receiver)
            //    .HasForeignKey(c => c.ReceiverId)
            //    .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
