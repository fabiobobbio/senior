using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Orchard.Domain;

namespace Orchard.Repository
{
    public abstract class Repository<TEntity> : IRepository<TEntity> where TEntity : Entity<int, TEntity>, new()
    {
        protected readonly OrchardContext Db;
        protected readonly DbSet<TEntity> DbSet;

        protected Repository(OrchardContext db)
        {
            Db = db;
            DbSet = db.Set<TEntity>();
        }

        public virtual async Task<TEntity> FindById(int id)
        {
            try 
            { 
                return await DbSet.FindAsync(id);
            }
            catch(Exception e)
            {
                throw;
            }
        }

        public virtual async Task<List<TEntity>> FindAll()
        {
            try 
            { 
                return await DbSet.AsNoTracking().ToListAsync(); 
            }
            catch(Exception e)
            {
                throw;
            }
        }

        public virtual async Task Create(TEntity entity)
        {
            try
            {
                DbSet.Add(entity);
                await SaveChanges();
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public virtual async Task Update(TEntity entity)
        {
            try
            {
                DbSet.Update(entity);
                await SaveChanges();
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public virtual async Task Delete(int id)
        {
            try { 
                DbSet.Remove(new TEntity { Id = id });
                await SaveChanges();
            }
            catch(Exception e)
            {
                throw;
            }
        }

        public async Task<int> SaveChanges()
        {
            try
            {
                return await Db.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public void Dispose()
        {
            Db?.Dispose();
        }
    }
}