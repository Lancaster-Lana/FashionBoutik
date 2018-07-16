using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using FashionBoutik.Entities;

namespace FashionBoutik.EntityFramework.Repository
{
    public class Repository<T, TKey> : IRepository<T, TKey> where T : BaseEntity<TKey>
    {
        private readonly DbContext context;
        private readonly DbSet<T> entities;

        string errorMessage = string.Empty;

        public Repository(DbContext context)
        {
            this.context = context;
            entities = context.Set<T>();
        }
        public async Task<IQueryable<T>> GetAll()
        {
            return await Task.FromResult(entities.AsQueryable());
        }

        public async virtual Task<T> GetById(TKey id)
        {
            return await entities.SingleOrDefaultAsync(s => s.Id.Equals(id));
        }

        //public async Task<T> GetByIdIncluding<TEntity, TProperty>(TKey id, Expression<Func<TEntity, TProperty>> expr) where TEntity : class
        //{
        //    return await entities.Include(expr).SingleOrDefaultAsync(s => s.Id.Equals(id));
        //}

        /// <summary>
        /// Supplementary method
        /// </summary>
        /// <param name="id"></param>
        /// <param name="exprs"></param>
        /// <returns></returns>
        public async Task<T> GetByIdIncluding(TKey id, params string[] exprs)
        {
            IQueryable<T> entitiesWithIncludes = entities;
            foreach(var expr in exprs)
                entitiesWithIncludes = entitiesWithIncludes.Include(expr);

            return await entitiesWithIncludes.SingleOrDefaultAsync(s => s.Id.Equals(id));
        }

        public async virtual Task<bool> Insert(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            var result = await entities.AddAsync(entity);

            await SaveChanges();

            return result.State == EntityState.Added;
        }

        public async virtual Task<bool> Update(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            var result = entities.Update(entity);

            await SaveChanges();
            return true;
        }

        public async virtual Task<bool> Delete(TKey id)
        {
            var entity = await GetById(id);
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }

            return await Delete(entity);
        }

        public async virtual Task<bool> Delete(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            bool removed = Remove(entity);
            await SaveChanges();

            return removed;
        }
        public virtual bool Remove(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            var result = entities.Remove(entity);

            return result.State == EntityState.Deleted;
        }

        public async virtual Task SaveChanges()
        {
            await context.SaveChangesAsync();
        }
    }
}
