using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using System.Net.Mail;
using Tomnaia.Data.Configuration;
using Tomnaia.Entities;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Tomnaia.Data
{
    public class AppDbContext(DbContextOptions options) : IdentityDbContext<User>(options)
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Vehicle> vehicles { get; set; }
        public DbSet<Notification> Notifications { get; set; }
        public DbSet<Rate> Rates { get; set; }

        public DbSet<Ride> Rides { get; set; }
        public DbSet<Comment> Comments { get; set; }
      
        public DbSet<Message> Messages { get; set; }

       
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);


            #region user
            new UserEntityTypeConfiguration().Configure(modelBuilder.Entity<User>());
            #endregion

            #region comment
            new CommentEntityTypeConfiguration().Configure(modelBuilder.Entity<Comment>());
            #endregion

            #region notification
            new NotificationEntityTypeConfiguration().Configure(modelBuilder.Entity<Notification>());
            #endregion
            #region rate
            new RateEntityTypeConfiguration().Configure(modelBuilder.Entity<Rate>());
            #endregion

            #region message
            new MessageEntityTypeConfiguration().Configure(modelBuilder.Entity<Message>());
            #endregion

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
