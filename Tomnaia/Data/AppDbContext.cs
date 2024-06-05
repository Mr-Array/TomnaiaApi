using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.DotNet.Scaffolding.Shared.Messaging;
using Microsoft.EntityFrameworkCore;
using Tomnaia.Entities;

namespace Tomnaia.Data
{
    public class AppDbContext(DbContextOptions options) : IdentityDbContext<User>(options)
    {
        //public DbSet<User> Users { get; set; }
        public DbSet<Driver> Drivers { get; set; }
        public DbSet<Adminstrator> Adminstrators { get; set; }
        public DbSet<Passenger> Passengers { get; set; }
        public DbSet<Vehicle> Vehicles { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<BlockRequest> BlockRequests { get; set; }

    
        public DbSet<Notification> Notifications { get; set; }
        public DbSet<Rate> Rates { get; set; }
        public DbSet<Ride> Rides { get; set; }
        public DbSet<Comment> Comments { get; set; }

         public DbSet<Entities.Message> Messages { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Passenger>().ToTable("Passengers");
            modelBuilder.Entity<Driver>().ToTable("Drivers");
            modelBuilder.Entity<Adminstrator>().ToTable("Admins");



            modelBuilder.Entity<Driver>()
                .HasMany(d => d.Vehicles)
                .WithOne(r => r.Driver)
                .HasForeignKey(r => r.DriverId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Entities.Message>(entity =>
            {
                entity.HasOne(m => m.SenderPassenger)
                      .WithMany(p => p.SentMessages)
                      .HasForeignKey(m => m.SenderPassengerId)
                      .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(m => m.SenderDriver)
                      .WithMany(d => d.SentMessages)
                      .HasForeignKey(m => m.SenderDriverId)
                      .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(m => m.ReceiverPassenger)
                      .WithMany(p => p.ReceivedMessages)
                      .HasForeignKey(m => m.ReceiverPassengerId)
                      .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(m => m.ReceiverDriver)
                      .WithMany(d => d.ReceivedMessages)
                      .HasForeignKey(m => m.ReceiverDriverId)
                      .OnDelete(DeleteBehavior.Restrict);
            });

            // Configure Passenger entity
            modelBuilder.Entity<Passenger>(entity =>
            {
                entity.HasMany(p => p.SentMessages)
                      .WithOne(m => m.SenderPassenger)
                      .HasForeignKey(m => m.SenderPassengerId)
                      .OnDelete(DeleteBehavior.Restrict);

                entity.HasMany(p => p.ReceivedMessages)
                      .WithOne(m => m.ReceiverPassenger)
                      .HasForeignKey(m => m.ReceiverPassengerId)
                      .OnDelete(DeleteBehavior.Restrict);

                entity.HasMany(p => p.Reviewer)
            .WithOne(r => r.Reviewer)
            .HasForeignKey(r => r.ReviewerId)
            .OnDelete(DeleteBehavior.Restrict);
            });

            // Configure Driver entity
            modelBuilder.Entity<Driver>(entity =>
            {
                entity.HasMany(d => d.SentMessages)
                      .WithOne(m => m.SenderDriver)
                      .HasForeignKey(m => m.SenderDriverId)
                      .OnDelete(DeleteBehavior.Restrict);

                entity.HasMany(d => d.ReceivedMessages)
                      .WithOne(m => m.ReceiverDriver)
                      .HasForeignKey(m => m.ReceiverDriverId)
                      .OnDelete(DeleteBehavior.Restrict);

                entity.HasMany(d => d.Reviewee)
            .WithOne(r => r.Reviewee)
            .HasForeignKey(r => r.RevieweeId)
            .OnDelete(DeleteBehavior.Restrict);
            });

           

            SeedRoles(modelBuilder);

        }

        private void SeedRoles(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<IdentityRole>().HasData
                (
                  new IdentityRole() { Id = "1", Name = "Passenger", NormalizedName = "Passenger" },
                  new IdentityRole() { Id = "2", Name = "Driver", NormalizedName = "Driver" },
                  new IdentityRole() { Id = "3", Name = "Admin", NormalizedName = "Admin" }
                );

        }
    }

}
