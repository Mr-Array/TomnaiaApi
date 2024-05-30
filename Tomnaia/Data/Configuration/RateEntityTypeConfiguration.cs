using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Tomnaia.Entities;

namespace Tomnaia.Data.Configuration
{
    public class RateEntityTypeConfiguration : IEntityTypeConfiguration<Rate>
    {
        public void Configure(EntityTypeBuilder<Rate> builder)
        {
            //builder
            //    .HasOne(r => r.Rater)
            //    .WithMany(u => u.SentRates)
            //    .HasForeignKey(r => r.RaterId)
            //    .OnDelete(DeleteBehavior.NoAction);

            //builder
            //    .HasOne(r => r.Rated)
            //    .WithMany(r => r.ReceivedRates)
            //    .HasForeignKey(r => r.RatedId)
            //    .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
