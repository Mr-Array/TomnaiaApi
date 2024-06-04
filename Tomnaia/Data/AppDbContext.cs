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

        /// </summary>
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


            //modelBuilder.Entity<RidePassenger>()
            //    .HasOne(rp => rp.Ride)
            //    .WithMany(r => r.RidePassengers)
            //    .HasForeignKey(rp => rp.RideId).OnDelete(DeleteBehavior.NoAction); ;

            //modelBuilder.Entity<RidePassenger>()
            //    .HasOne(rp => rp.Passenger)
            //    .WithMany(p => p.RidePassengers)
            //    .HasForeignKey(rp => rp.PassengerId).OnDelete(DeleteBehavior.NoAction);


            //modelBuilder.Entity<Driver>()
            //    .HasOne(d => d.Vehicles)
            //    .WithMany()
            //    .HasForeignKey(v => v.dri)
            //    .OnDelete(DeleteBehavior.NoAction);
       //     modelBuilder.Entity<Ride>()
       //.HasOne(r => r.VehicleId)
       //.WithMany(p => p.)
       //.HasForeignKey(r => r.PassengerId);

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

            //modelBuilder.Entity<Driver>()
            //.HasMany(d => d.Reviewee)
            //.WithOne(r => r.Reviewee)
            //.HasForeignKey(r => r.RevieweeId)
            //.OnDelete(DeleteBehavior.Restrict);

            //modelBuilder.Entity<Passenger>()
            //.HasMany(p => p.Reviewer)
            //.WithOne(r => r.Reviewer)
            //.HasForeignKey(r => r.ReviewerId)
            //.OnDelete(DeleteBehavior.Restrict);
            // Configure other relationships similarly to avoid multiple cascade paths





            //    // Passenger configuration
            //    modelBuilder.Entity<Passenger>()
            //        .HasKey(p => p.PassengerId);

            //    //modelBuilder.Entity<Passenger>()
            //    //    .HasOne(p => p.Account)
            //    //    .WithMany(u => u.Passenger)
            //    //    .HasForeignKey(p => p.AccountId)
            //    //    .OnDelete(DeleteBehavior.NoAction);

            //    modelBuilder.Entity<Passenger>()
            //        .HasMany(p => p.RidePassengers)
            //        .WithOne(rp => rp.Passenger)
            //        .HasForeignKey(rp => rp.PassengerId)
            //        .OnDelete(DeleteBehavior.NoAction);

            //    // Vehicle configuration
            //    modelBuilder.Entity<Vehicle>()
            //        .HasKey(v => v.VehicleId);

            //    modelBuilder.Entity<Vehicle>()
            //        .HasOne(v => v.Driver)
            //        .WithMany(d => d.Vehicles)
            //        .HasForeignKey(v => v.DriverId)
            //        .OnDelete(DeleteBehavior.Restrict);

            //modelBuilder.Entity<Vehicle>()
            //    .HasMany(v => v.Rides)
            //    .WithOne(r => r.Vehicle)
            //    .HasForeignKey(r => r.VehicleId)
            //    .OnDelete(DeleteBehavior.NoAction);

            //    // Ride configuration
            //    modelBuilder.Entity<Ride>()
            //        .HasKey(r => r.RideId);

            //    modelBuilder.Entity<Ride>()
            //       .HasOne(r => r.Vehicle)
            //       .WithMany(v => v.Rides)
            //       .HasForeignKey(r => r.VehicleId)
            //       .OnDelete(DeleteBehavior.Restrict); // Disable cascading delete

            //    modelBuilder.Entity<Ride>()
            //        .HasOne(r => r.Driver)
            //        .WithMany(d => d.Rides)
            //        .HasForeignKey(r => r.DriverId)
            //        .OnDelete(DeleteBehavior.Restrict);

            //    modelBuilder.Entity<Ride>()
            //        .HasMany(r => r.Reviews)
            //        .WithOne(rv => rv.Ride)
            //        .HasForeignKey(rv => rv.RideId)
            //        .OnDelete(DeleteBehavior.NoAction);

            //    modelBuilder.Entity<Ride>()
            //        .HasMany(r => r.RidePassengers)
            //        .WithOne(rp => rp.Ride)
            //        .HasForeignKey(rp => rp.RideId)
            //        .OnDelete(DeleteBehavior.NoAction);

            //    // Review configuration
            //    modelBuilder.Entity<Review>()
            //        .HasKey(rv => rv.ReviewId);

            //    modelBuilder.Entity<Review>()
            //        .HasOne(rv => rv.Ride)
            //        .WithMany(r => r.Reviews)
            //        .HasForeignKey(rv => rv.RideId)
            //        .OnDelete(DeleteBehavior.NoAction);

            //    //modelBuilder.Entity<Review>()
            //    //    .HasOne(rv => rv.User)
            //    //    .WithMany(u => u.Reviews)
            //    //    .HasForeignKey(rv => rv.UserId)
            //    //    .OnDelete(DeleteBehavior.NoAction);

            //    // RidePassenger configuration (junction table)
            //    modelBuilder.Entity<RidePassenger>()
            //        .HasKey(rp => new { rp.RideId, rp.PassengerId });

            //    modelBuilder.Entity<RidePassenger>()
            //        .HasOne(rp => rp.Ride)
            //        .WithMany(r => r.RidePassengers)
            //        .HasForeignKey(rp => rp.RideId)
            //        .OnDelete(DeleteBehavior.NoAction);

            //    modelBuilder.Entity<RidePassenger>()
            //        .HasOne(rp => rp.Passenger)
            //        .WithMany(p => p.RidePassengers)
            //        .HasForeignKey(rp => rp.PassengerId)
            //        .OnDelete(DeleteBehavior.NoAction);
            //    //modelBuilder.Entity<User>()
            //    //    .HasMany(c => c.SentMessages)
            //    //    .WithOne(u => u.Sender)
            //    //    .HasForeignKey(c => c.SenderId)
            //    //    .OnDelete(DeleteBehavior.Cascade);

            //    //modelBuilder.Entity<User>()
            //    //    .HasMany(c => c.ReceivedMessages)
            //    //    .WithOne(u => u.Receiver)
            //    //    .HasForeignKey(c => c.ReceiverId)
            //    //    .OnDelete(DeleteBehavior.Cascade);

            //    //modelBuilder.Entity<Entities.Message>()
            //    //    .HasOne(c => c.Sender)
            //    //    .WithMany(u => u.SentMessages)
            //    //    .HasForeignKey(c => c.SenderId)
            //    //    .OnDelete(DeleteBehavior.NoAction);

            //    //modelBuilder.Entity<Entities.Message>()
            //    //    .HasOne(c => c.Receiver)
            //    //    .WithMany(u => u.ReceivedMessages)
            //    //    .HasForeignKey(c => c.ReceiverId)
            //    //    .OnDelete(DeleteBehavior.NoAction);




            //    //modelBuilder.Entity<User>()
            //    //    .HasMany(c => c.SentRates)
            //    //    .WithOne(u => u.Rater)
            //    //    .HasForeignKey(c => c.RaterId)
            //    //    .OnDelete(DeleteBehavior.Cascade);

            //    //modelBuilder.Entity<User>()
            //    //    .HasMany(c => c.ReceivedRates)
            //    //    .WithOne(u => u.Rated)
            //    //    .HasForeignKey(c => c.RatedId)
            //    //    .OnDelete(DeleteBehavior.Cascade);

            //    //modelBuilder.Entity<Rate>()
            //    //    .HasOne(c => c.Rater)
            //    //    .WithMany(u => u.SentRates)
            //    //    .HasForeignKey(c => c.RaterId)
            //    //    .OnDelete(DeleteBehavior.NoAction);

            //    //modelBuilder.Entity<Rate>()
            //    //    .HasOne(c => c.Rated)
            //    //    .WithMany(u => u.ReceivedRates)
            //    //    .HasForeignKey(c => c.RatedId)
            //    //    .OnDelete(DeleteBehavior.NoAction);


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
