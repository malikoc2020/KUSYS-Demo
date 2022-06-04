using Domain.Base;
using EFCore.Repository.UnitOfWork;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace EFCore.Repository.Repository
{
    public class Repository<T> : IRepository<T> where T : BaseEntity
    {
        public readonly IUnitOfWork unitOfWork;
        public Repository(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public IQueryable<T> GetAll()
        {
            return unitOfWork.Context.Set<T>().AsQueryable();
        }
        public DbSet<T> GetAllEntities()
        {
            return unitOfWork.Context.Set<T>();
        }
        public T GetById(int Id)
        {
            return GetAll().Where(x => x.Id == Id).FirstOrDefault();
        }
        public void Add(T entity)
        {
            unitOfWork.Context.Set<T>().Add(entity);
        }
        public void AddRange(List<T> entities)
        {
            unitOfWork.Context.Set<T>().AddRange(entities);
        }
        public void Update(T entity)
        {
            unitOfWork.Context.Entry(entity).State = EntityState.Modified;
        }
        public void UpdateRange(List<T> entities)
        {
            unitOfWork.Context.Entry(entities).State = EntityState.Modified;
        }
        public void Delete(T entity)
        {
            unitOfWork.Context.Entry(entity).State = EntityState.Deleted;
        }
    }
}
