using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Microsoft.DotNet.Scaffolding.Shared.Messaging;
using System.Reflection.Emit;
using Tomnaia.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using Message = Tomnaia.Entities.Message;

namespace Tomnaia.Data.Configuration
{
    public class MessageEntityTypeConfiguration : IEntityTypeConfiguration<Message>
    {
        public void Configure(EntityTypeBuilder<Message> builder)
        {
            //builder
            //    .HasOne(c => c.Sender)
            //    .WithMany(u => u.SentMessages)
            //    .HasForeignKey(c => c.SenderId)
            //    .OnDelete(DeleteBehavior.Restrict);

            //builder
            //    .HasOne(c => c.Receiver)
            //    .WithMany(u => u.ReceivedMessages)
            //    .HasForeignKey(c => c.ReceiverId)
            //    .OnDelete(DeleteBehavior.Restrict);

        }
    }
}
