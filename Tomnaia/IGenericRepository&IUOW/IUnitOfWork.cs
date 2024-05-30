using Microsoft.Extensions.Hosting;
using static System.Runtime.InteropServices.JavaScript.JSType;
using Tomnaia.Entities;

namespace Tomnaia.IGenericRepository
{
    public interface IUnitOfWork
    {
        IGenericRepository<User> User { get; set; }
        IGenericRepository<Adminstrator> Adminstrator { get; set; }
        IGenericRepository<Driver> Driver { get; set; }
        IGenericRepository<Passenger> Passenger { get; set; }
        IGenericRepository<Vehicle> Vehicle { get; set; }
        IGenericRepository<Ride> Ride { get; set; }
        IGenericRepository<Review> Review { get; set; }
        IGenericRepository<RidePassenger> RidePassenger { get; set; }
        IGenericRepository<Comment> Comment { get; set; }
        IGenericRepository<Rate> Rate { get; set; }
        IGenericRepository<Message> Message { get; set; }
        IGenericRepository<Notification> Notification { get; set; }

        // Synchronous transaction methods

        int Save();

        // Asynchronous transaction methods
        Task CreateTransactionAsync();
        Task CommitAsync();
        Task CreateSavePointAsync(string point);
        Task RollbackAsync();
        Task RollbackToSavePointAsync(string point);
        Task<int> SaveAsync();
    }
}
