using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using ToDo.DomainModel;

namespace ToDo.Repository
{

    public class ToDoRepository<TEntity> : IGenericRepository<TEntity> where TEntity : BaseEntity
    {
        private ToDoContext context;
        private readonly DbSet<TEntity> dbSet;

        public ToDoRepository()
        {
            context = new ToDoContext();
            dbSet = context.Set<TEntity>();
        }

        ~ToDoRepository()
        {
            Dispose(false);
        }

        public void Add(TEntity entity)
        {
            dbSet.Add(entity);
        }

        public void Remove(TEntity entity)
        {
            dbSet.Remove(entity);
        }


        public int SaveChanges()
        {
            return context.SaveChanges();
        }


        public IQueryable<TEntity> Query(Expression<Func<TEntity, bool>> filter = null)
        {
            if (filter != null)
                return dbSet.Where(filter);

            return dbSet.AsQueryable();
        }

        public IQueryable<T> Query<T>() where T : class
        {
            IQueryable<T> query = context.Set<T>();

            return query;
        }

        public IQueryable<T> Query<T>(Expression<Func<T, bool>> filter) where T : class
        {
            IQueryable<T> query = context.Set<T>().Where(filter);

            return query;
        }

        public bool Any(Expression<Func<TEntity, bool>> filter)
        {
            return dbSet.Any(filter);
        }

        public TEntity FirstOrDefault(Expression<Func<TEntity, bool>> filter)
        {
            return dbSet.FirstOrDefault(filter);
        }

        public TEntity SingleOrDefault(Expression<Func<TEntity, bool>> filter)
        {
            return dbSet.SingleOrDefault(filter);
        }

        public DbContextTransaction BeginTransaction()
        {
            return context.Database.BeginTransaction();
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing && context != null)
            {
                context.Dispose();
                context = null;
            }
        }
    }

}
