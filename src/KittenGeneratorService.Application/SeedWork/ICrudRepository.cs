using System.Collections.Generic;

namespace KittenGeneratorService.Application.SeedWork
{
    public interface ICrudRepository<TEntity, TKey> where TEntity : class
    {
        IEnumerable<TEntity> Get(bool asNoTracking = true);

        TEntity Find(TKey id);

        TEntity Add(TEntity entity);

        TEntity Update(TEntity entity);

        void Delete(TEntity entity);
    }
}
