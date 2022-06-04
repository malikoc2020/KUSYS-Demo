using EFCore.Context;
using EFCore.Repository.Repository;

namespace EFCore.Repository.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        public AppDbContext Context { get; }
        public UnitOfWork(AppDbContext context)
        {
            Context = context;
        }

        public void Commit()
        {
            Context.SaveChanges();
        }
        public void Dispose()
        {
            Context?.Dispose();
        }
    }
}
