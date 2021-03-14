using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Orchard.Domain;

namespace Orchard.Repository
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