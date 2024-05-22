﻿using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using System.Net.Mail;
using Tomnaia.Entities;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Tomnaia.Data
{
    public class AppDbContext(DbContextOptions options) : IdentityDbContext<User>(options)
    {
        public DbSet<User> Users { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);


            

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