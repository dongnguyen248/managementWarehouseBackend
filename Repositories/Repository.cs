using Data;
using Microsoft.EntityFrameworkCore;
using Repositories.Interfaces;
using System;
using System.Linq;
using System.Linq.Expressions;

namespace Repositories
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        protected readonly DbSet<TEntity> _dbSet;
        protected readonly WarehouseManagementContext _dbContext;

        public Repository(WarehouseManagementContext dbContext)
        {
            _dbContext = dbContext;
            _dbContext.ChangeTracker.LazyLoadingEnabled = false;
            _dbSet = _dbContext.Set<TEntity>();
            //Scaffold-DbContext "Data Source=DESKTOP-V0UCT67\SQLEXPRESS;Initial Catalog=WarehouseManagement;User ID=sa;Password=sa;" Microsoft.EntityFrameworkCore.SqlServer -Force
        }

        public void Add(TEntity entity)
        {
            _dbSet.Add(entity);
        }

        public IQueryable<TEntity> FindAll(params Expression<Func<TEntity, object>>[] properties)
        {
            var query = _dbSet.AsQueryable();
            query = properties.Aggregate(query, (current, property) => current.Include(property));
            return query;
        }

        public IQueryable<TEntity> FindAll(Expression<Func<TEntity, bool>> predicate, params Expression<Func<TEntity, object>>[] properties)
        {
            var query = _dbSet.AsQueryable();
            query = properties.Aggregate(query, (current, property) => current.Include(property));
            return query.Where(predicate);
        }

        public TEntity FindById(object id)
        {
            return _dbSet.Find(id);
        }

        public TEntity FindSingle(Expression<Func<TEntity, bool>> predicate, params Expression<Func<TEntity, object>>[] properties)
        {
            return FindAll(properties).AsNoTracking().FirstOrDefault(predicate);
        }

        public void Remove(TEntity entity)
        {
            _dbSet.Remove(entity);
        }

        public void Remove(object id)
        {
            TEntity entity = _dbSet.Find(id);
            Remove(entity);
        }

        public void Update(TEntity entity)
        {
            _dbSet.Update(entity);
        }

        public void Dispose()
        {
            if (_dbContext != null)
            {
                _dbContext.Dispose();
            }
        }

        public void Update(TEntity entity, params Expression<Func<TEntity, object>>[] properties)
        {
            _dbSet.Attach(entity);
            var dbEntry = _dbContext.Entry(entity);
            foreach (var includeProperty in properties)
            {
                dbEntry.Property(includeProperty).IsModified = true;
            }
        }
    }
}