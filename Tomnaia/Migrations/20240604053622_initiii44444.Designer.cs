﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Tomnaia.Data;

#nullable disable

namespace Tomnaia.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20240604053622_initiii44444")]
    partial class initiii44444
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles", (string)null);

                    b.HasData(
                        new
                        {
                            Id = "1",
                            Name = "Passenger",
                            NormalizedName = "Passenger"
                        },
                        new
                        {
                            Id = "2",
                            Name = "Driver",
                            NormalizedName = "Driver"
                        },
                        new
                        {
                            Id = "3",
                            Name = "Admin",
                            NormalizedName = "Admin"
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("Tomnaia.Entities.BlockRequest", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Reason")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RequesterId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime>("ReviewedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TargetUserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("RequesterId");

                    b.ToTable("BlockRequests");
                });

            modelBuilder.Entity("Tomnaia.Entities.Comment", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Timestamp")
                        .HasColumnType("datetime2");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Comments");
                });

            modelBuilder.Entity("Tomnaia.Entities.Message", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ReceiverDriverId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ReceiverPassengerId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("SenderDriverId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("SenderPassengerId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime>("Timestamp")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("ReceiverDriverId");

                    b.HasIndex("ReceiverPassengerId");

                    b.HasIndex("SenderDriverId");

                    b.HasIndex("SenderPassengerId");

                    b.ToTable("Messages");
                });

            modelBuilder.Entity("Tomnaia.Entities.Notification", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DriverId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("PassengerId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime>("Timestamp")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("DriverId");

                    b.HasIndex("PassengerId");

                    b.ToTable("Notifications");
                });

            modelBuilder.Entity("Tomnaia.Entities.Rate", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<double>("RateValue")
                        .HasColumnType("float");

                    b.Property<string>("RaterId")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Rates");
                });

            modelBuilder.Entity("Tomnaia.Entities.Review", b =>
                {
                    b.Property<string>("ReviewId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<int>("Rating")
                        .HasColumnType("int");

                    b.Property<string>("RevieweeId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ReviewerId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RideRequestId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("ReviewId");

                    b.HasIndex("RevieweeId");

                    b.HasIndex("ReviewerId");

                    b.HasIndex("RideRequestId");

                    b.ToTable("Reviews");
                });

            modelBuilder.Entity("Tomnaia.Entities.Ride", b =>
                {
                    b.Property<string>("RideId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("DropoffLocation")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("EndTime")
                        .HasColumnType("datetime2");

                    b.Property<double>("Fare")
                        .HasColumnType("float");

                    b.Property<string>("PassengerId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("PickupLocation")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("RequestTime")
                        .HasColumnType("datetime2");

                    b.Property<int>("Rider")
                        .HasColumnType("int");

                    b.Property<DateTime>("StartTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("VehicleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("RideId");

                    b.HasIndex("PassengerId");

                    b.HasIndex("VehicleId");

                    b.ToTable("Rides");
                });

            modelBuilder.Entity("Tomnaia.Entities.User", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<int>("AccountType")
                        .HasColumnType("int");

                    b.Property<string>("City")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Country")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("ProfilePicture")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<string>("Street")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers", (string)null);

                    b.UseTptMappingStrategy();
                });

            modelBuilder.Entity("Tomnaia.Entities.Vehicle", b =>
                {
                    b.Property<string>("VehicleId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("Capacity")
                        .HasColumnType("int");

                    b.Property<string>("DriverId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("LicenseStatus")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Model")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhotoVehicle")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Photolicense")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("VehicleType")
                        .HasColumnType("int");

                    b.Property<string>("Year")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("VehicleId");

                    b.HasIndex("DriverId");

                    b.ToTable("Vehicles");
                });

            modelBuilder.Entity("Tomnaia.Entities.Adminstrator", b =>
                {
                    b.HasBaseType("Tomnaia.Entities.User");

                    b.ToTable("Admins", (string)null);
                });

            modelBuilder.Entity("Tomnaia.Entities.Driver", b =>
                {
                    b.HasBaseType("Tomnaia.Entities.User");

                    b.Property<string>("DriverLicenseNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LicensePhoto")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NationalId")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NationalPhoto")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("expirDate")
                        .HasColumnType("datetime2");

                    b.ToTable("Drivers", (string)null);
                });

            modelBuilder.Entity("Tomnaia.Entities.Passenger", b =>
                {
                    b.HasBaseType("Tomnaia.Entities.User");

                    b.ToTable("Passengers", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("Tomnaia.Entities.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("Tomnaia.Entities.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Tomnaia.Entities.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("Tomnaia.Entities.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Tomnaia.Entities.BlockRequest", b =>
                {
                    b.HasOne("Tomnaia.Entities.Adminstrator", "Requester")
                        .WithMany()
                        .HasForeignKey("RequesterId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Requester");
                });

            modelBuilder.Entity("Tomnaia.Entities.Comment", b =>
                {
                    b.HasOne("Tomnaia.Entities.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("Tomnaia.Entities.Message", b =>
                {
                    b.HasOne("Tomnaia.Entities.Driver", "ReceiverDriver")
                        .WithMany("ReceivedMessages")
                        .HasForeignKey("ReceiverDriverId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("Tomnaia.Entities.Passenger", "ReceiverPassenger")
                        .WithMany("ReceivedMessages")
                        .HasForeignKey("ReceiverPassengerId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("Tomnaia.Entities.Driver", "SenderDriver")
                        .WithMany("SentMessages")
                        .HasForeignKey("SenderDriverId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("Tomnaia.Entities.Passenger", "SenderPassenger")
                        .WithMany("SentMessages")
                        .HasForeignKey("SenderPassengerId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.Navigation("ReceiverDriver");

                    b.Navigation("ReceiverPassenger");

                    b.Navigation("SenderDriver");

                    b.Navigation("SenderPassenger");
                });

            modelBuilder.Entity("Tomnaia.Entities.Notification", b =>
                {
                    b.HasOne("Tomnaia.Entities.Driver", "ReceiverDriver")
                        .WithMany("Notifications")
                        .HasForeignKey("DriverId");

                    b.HasOne("Tomnaia.Entities.Passenger", "ReceiverPassenger")
                        .WithMany("Notifications")
                        .HasForeignKey("PassengerId");

                    b.Navigation("ReceiverDriver");

                    b.Navigation("ReceiverPassenger");
                });

            modelBuilder.Entity("Tomnaia.Entities.Review", b =>
                {
                    b.HasOne("Tomnaia.Entities.Driver", "Reviewee")
                        .WithMany("Reviewee")
                        .HasForeignKey("RevieweeId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("Tomnaia.Entities.Passenger", "Reviewer")
                        .WithMany("Reviewer")
                        .HasForeignKey("ReviewerId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("Tomnaia.Entities.Ride", "Rides")
                        .WithMany()
                        .HasForeignKey("RideRequestId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Reviewee");

                    b.Navigation("Reviewer");

                    b.Navigation("Rides");
                });

            modelBuilder.Entity("Tomnaia.Entities.Ride", b =>
                {
                    b.HasOne("Tomnaia.Entities.Passenger", "Passenger")
                        .WithMany()
                        .HasForeignKey("PassengerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Tomnaia.Entities.Vehicle", "Vehicle")
                        .WithMany()
                        .HasForeignKey("VehicleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Passenger");

                    b.Navigation("Vehicle");
                });

            modelBuilder.Entity("Tomnaia.Entities.Vehicle", b =>
                {
                    b.HasOne("Tomnaia.Entities.Driver", "Driver")
                        .WithMany("Vehicles")
                        .HasForeignKey("DriverId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Driver");
                });

            modelBuilder.Entity("Tomnaia.Entities.Adminstrator", b =>
                {
                    b.HasOne("Tomnaia.Entities.User", null)
                        .WithOne()
                        .HasForeignKey("Tomnaia.Entities.Adminstrator", "Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Tomnaia.Entities.Driver", b =>
                {
                    b.HasOne("Tomnaia.Entities.User", null)
                        .WithOne()
                        .HasForeignKey("Tomnaia.Entities.Driver", "Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Tomnaia.Entities.Passenger", b =>
                {
                    b.HasOne("Tomnaia.Entities.User", null)
                        .WithOne()
                        .HasForeignKey("Tomnaia.Entities.Passenger", "Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Tomnaia.Entities.Driver", b =>
                {
                    b.Navigation("Notifications");

                    b.Navigation("ReceivedMessages");

                    b.Navigation("Reviewee");

                    b.Navigation("SentMessages");

                    b.Navigation("Vehicles");
                });

            modelBuilder.Entity("Tomnaia.Entities.Passenger", b =>
                {
                    b.Navigation("Notifications");

                    b.Navigation("ReceivedMessages");

                    b.Navigation("Reviewer");

                    b.Navigation("SentMessages");
                });
#pragma warning restore 612, 618
        }
    }
}
