using KittenGeneratorService.Application.SeedWork;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KittenGeneratorService.Infrastructure.Domain.SeedWork
{
    /// <summary>
    /// Basic crud repository concrete implementation
    /// </summary>
    /// <typeparam name="TContext">Type of DbContext</typeparam>
    /// <typeparam name="TEntity">Type of the entity</typeparam>
    /// <typeparam name="TKey">Type of primary key of the entity</typeparam>
    public abstract class CrudRepository<TContext, TEntity, TKey> : ICrudRepository<TEntity, TKey>
      where TEntity : class
      where TContext : DbContext
    {
        protected readonly TContext _context;

        public CrudRepository(TContext context)
        {
            _context = context;
        }

        protected virtual IQueryable<TEntity> GetQueryable(bool asNoTracking = true)
        {
            var q = _context.Set<TEntity>();

            return asNoTracking ? q.AsNoTracking() : q;
        }

        public virtual IEnumerable<TEntity> Get(bool asNoTracking = true)
        {
            return GetQueryable(asNoTracking).ToList();
        }

        public virtual TEntity Find(TKey id)
        {
            return _context.Set<TEntity>().Find(id);
        }

        public virtual TEntity Add(TEntity entity)
        {
            return _context.Set<TEntity>().Add(entity).Entity;
        }

        public virtual TEntity Update(TEntity entity)
        {
            return _context.Set<TEntity>().Update(entity).Entity;
        }

        public virtual void Delete(TEntity entity)
        {
            _context.Set<TEntity>().Remove(entity);
        }
    }
}
