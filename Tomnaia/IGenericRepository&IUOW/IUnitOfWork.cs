﻿using Microsoft.Extensions.Hosting;
using static System.Runtime.InteropServices.JavaScript.JSType;
using Tomnaia.Entities;

namespace Tomnaia.IGenericRepository
{
    public interface IUnitOfWork
    {
        IGenericRepository<User> User { get; set; }
      

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