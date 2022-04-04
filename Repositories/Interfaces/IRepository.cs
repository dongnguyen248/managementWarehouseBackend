using System;
using System.Linq;
using System.Linq.Expressions;

namespace Repositories.Interfaces
{
    public interface IRepository<TEntity> : IDisposable
    {
        void Add(TEntity entity);

        IQueryable<TEntity> FindAll(params Expression<Func<TEntity, object>>[] includeProperties);

        IQueryable<TEntity> FindAll(Expression<Func<TEntity, bool>> predicate, params Expression<Func<TEntity, object>>[] includeProperties);

        TEntity FindById(object id);

        TEntity FindSingle(Expression<Func<TEntity, bool>> predicate, params Expression<Func<TEntity, object>>[] includeProperties);

        void Remove(TEntity entity);

        void Remove(object id);

        void Update(TEntity entity);
    }
}