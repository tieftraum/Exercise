using System;
using System.Threading.Tasks;

namespace Exercise.Domain.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        Task<bool> SaveChangesAsync();
    }
}