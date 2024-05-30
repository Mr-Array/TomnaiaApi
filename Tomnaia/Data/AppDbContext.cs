using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.DotNet.Scaffolding.Shared.Messaging;
using Microsoft.EntityFrameworkCore;
using Tomnaia.Entities;

namespace Tomnaia.Data
{
    public class AppDbContext(DbContextOptions options) : IdentityDbContext<User>(options)
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Driver> Drivers { get; set; }
        public DbSet<Adminstrator> Adminstrators { get; set; }
        public DbSet<Passenger> Passengers { get; set; }
        public DbSet<Vehicle> Vehicles { get; set; }
        public DbSet<Review> Reviews { get; set; }
        
        /// </summary>
        public DbSet<Notification> Notifications { get; set; }
        public DbSet<Rate> Rates { get; set; }
        public DbSet<Ride> Rides { get; set; }
        public DbSet<RidePassenger> RidePassengers { get; set; }
        public DbSet<Comment> Comments { get; set; }

        // public DbSet<Entities.Message> Messages { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<RidePassenger>()
                 .HasKey(rp => new { rp.RideId, rp.PassengerId });

            //modelBuilder.Entity<RidePassenger>()
            //    .HasOne(rp => rp.Ride)
            //    .WithMany(r => r.RidePassengers)
            //    .HasForeignKey(rp => rp.RideId).OnDelete(DeleteBehavior.NoAction); ;

            //modelBuilder.Entity<RidePassenger>()
            //    .HasOne(rp => rp.Passenger)
            //    .WithMany(p => p.RidePassengers)
            //    .HasForeignKey(rp => rp.PassengerId).OnDelete(DeleteBehavior.NoAction);


            modelBuilder.Entity<Driver>()
                .HasOne(d=>d.Vehicle)
                .WithMany()
                .HasForeignKey(v => v.DriverId)
                .OnDelete(DeleteBehavior.NoAction);

            //    modelBuilder.Entity<Driver>()
            //        .HasMany(d => d.Rides)
            //        .WithOne(r => r.Driver)
            //        .HasForeignKey(r => r.DriverId)
            //        .OnDelete(DeleteBehavior.NoAction);

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

            modelBuilder.Entity<Vehicle>()
                .HasMany(v => v.Rides)
                .WithOne(r => r.Vehicle)
                .HasForeignKey(r => r.VehicleId)
                .OnDelete(DeleteBehavior.NoAction);

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
