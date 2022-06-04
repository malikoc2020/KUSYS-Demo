using EFCore.Context;
using System;

namespace EFCore.Repository.UnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        AppDbContext Context { get; }
        void Commit();
    }
}
