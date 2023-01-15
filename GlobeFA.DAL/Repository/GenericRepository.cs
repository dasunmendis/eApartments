using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;

namespace GlobeFa.DAL.Repository
{
    public class GenericRepository<T> where T : class
    {
        internal GlobeFAContext context;
        internal DbSet<T> dbSet;

        public GenericRepository(GlobeFAContext context)
        {
            this.context = context;
            this.dbSet = context.Set<T>();
        }

        public virtual IEnumerable<T> GetAll(Expression<Func<T, bool>> filter = null,
            Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null, string includeProperties = "")
        {
            IQueryable<T> query = dbSet;

            if (filter != null)
            {
                query = query.Where(filter);
            }

            foreach (var includeProperty in includeProperties.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
            {
                query = query.Include(includeProperty);
            }

            return (orderBy != null) ? orderBy(query).ToList() : query.ToList();
        }

        public virtual T GetById(object id)
        {
            return dbSet.Find(id);
        }

        public virtual void Insert(T entity)
        {
            dbSet.Add(entity);
        }

        public virtual void Update(T entityToUpdate)
        {
            var entry = context.Entry(entityToUpdate);
            var primaryKey = dbSet.Create().GetType().GetProperty("Id").GetValue(entityToUpdate);

            if (entry.State != EntityState.Detached) return;
            var set = context.Set<T>();
            var attachedEntity = set.Find(primaryKey);
            if (attachedEntity != null)
            {
                var attachedEntry = context.Entry(attachedEntity);
                attachedEntry.CurrentValues.SetValues(entityToUpdate);
            }
            else
            {
                entry.State = EntityState.Modified;
            }
        }

        public virtual void DeleteById(object id)
        {
            T entityToDelete = dbSet.Find(id);
            Delete(entityToDelete);
        }

        public virtual void Delete(T entityToDelete)
        {
            if (context.Entry(entityToDelete).State == EntityState.Detached)
            {
                dbSet.Attach(entityToDelete);
            }
            dbSet.Remove(entityToDelete);
        }
    }
}
