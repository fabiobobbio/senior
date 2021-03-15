using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Orchard.Domain
{
    public interface IRepository<TEntity> : IDisposable where TEntity : Entity<int, TEntity>
    {
        Task Create(TEntity entity);
        Task<TEntity> FindById(int id);
        Task<List<TEntity>> FindAll();
        Task Update(TEntity entity);
        Task Delete(int id);
        Task<int> SaveChanges();
    }
}