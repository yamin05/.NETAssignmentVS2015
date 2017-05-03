using System;

namespace WebApplication1.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        void SaveChanges();
    }
}
