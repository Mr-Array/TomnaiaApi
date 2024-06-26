﻿using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.Extensions.Hosting;
using static System.Runtime.InteropServices.JavaScript.JSType;
using Tomnaia.Data;
using Tomnaia.Entities;
using Tomnaia.IGenericRepository;

namespace Tomnaia.GenericRepository_UOW
{
    public class UnitOfWork : IUnitOfWork
    {
        private IDbContextTransaction transaction;

        private readonly AppDbContext _context;
        public IGenericRepository<User> User { get; set; }
        public IGenericRepository<Driver> Driver { get; set; }
        public IGenericRepository<Passenger> Passenger { get; set; }
        public IGenericRepository<Adminstrator> Adminstrator { get; set; }
        public IGenericRepository<Vehicle> Vehicle { get; set; }
        public IGenericRepository<Review> Review { get; set; }
        public IGenericRepository<Comment> Comment { get ; set ; }
        public IGenericRepository<Rate> Rate { get ; set; }
        public IGenericRepository<Message> Message { get; set ; }
        public IGenericRepository<Notification> Notification { get ; set ; }
        public IGenericRepository<Ride> Ride { get; set; }

        public UnitOfWork(AppDbContext context)
        {
            _context = context;
            User = new GenericRepository<User>(_context);
            Comment = new GenericRepository<Comment>(_context);
            Rate = new GenericRepository<Rate>(_context);
            Message = new GenericRepository<Message>(_context);
            Driver = new GenericRepository<Driver>(_context);
            Passenger = new GenericRepository<Passenger>(_context);
            Vehicle = new GenericRepository<Vehicle>(_context);
            Adminstrator = new GenericRepository<Adminstrator>(_context);
            Review = new GenericRepository<Review>(_context);
            Ride = new GenericRepository<Ride>(_context);

        }

        public async Task CreateTransactionAsync()
        {
            transaction = await _context.Database.BeginTransactionAsync();
        }

        public async Task CommitAsync()
        {
            await transaction.CommitAsync();
        }

        public async Task CreateSavePointAsync(string point)
        {
            await transaction.CreateSavepointAsync(point);
        }

        public async Task RollbackAsync()
        {
            await transaction.RollbackAsync();
        }

        public async Task RollbackToSavePointAsync(string point)
        {
            await transaction.RollbackToSavepointAsync(point);
        }

        public int Save()
        {
            return _context.SaveChanges();
        }

        public async Task<int> SaveAsync()
        {
            return await _context.SaveChangesAsync();
        }
    }
}
