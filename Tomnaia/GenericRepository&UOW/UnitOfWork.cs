using Microsoft.EntityFrameworkCore.Storage;
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
        public IGenericRepository<Comment> Comment { get ; set ; }
        public IGenericRepository<Rate> Rate { get ; set; }
        public IGenericRepository<Message> Message { get; set ; }
        public IGenericRepository<Notification> Notification { get ; set ; }

        public UnitOfWork(AppDbContext context)
        {
            _context = context;
            User = new GenericRepository<User>(_context);
            Comment = new GenericRepository<Comment>(_context);
            Rate = new GenericRepository<Rate>(_context);
            Message = new GenericRepository<Message>(_context);
            Notification = new GenericRepository<Notification>(_context);

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
