using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using CA.Core.Application.Repositories.Base;
using Microsoft.EntityFrameworkCore;

namespace CA.Infrastructure.Persistence.Repositories.Base
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        private readonly ApplicationDbContext _context;
        protected DbSet<TEntity> dbSet;

        public Repository(
            ApplicationDbContext context
        )
        {
            _context = context;
            dbSet = _context.Set<TEntity>();
        }

        public virtual async Task<bool> Add(TEntity entity)
        {
            try
            {
                if (entity == null)
                    throw new ArgumentNullException(nameof(entity));

                await dbSet.AddAsync(entity);
                return true;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public virtual async Task<bool> Delete<Guid>(Guid ID)
        {
            try
            {
                var entity = await dbSet.FindAsync(ID);
                if (entity == null)
                    return false;

                dbSet.Remove(entity);

                return true;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public virtual async Task<bool> Delete(TEntity entity)
        {
            try
            {
                if (entity == null)
                    return false;

                dbSet.Remove(entity);
                return true;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public virtual async Task<bool> Delete(Expression<Func<TEntity, bool>> where)
        {
            try
            {
                var entities = dbSet.Where(where);
                dbSet.RemoveRange(entities);

                return true;
            }
            catch (DbUpdateException)
            {
                throw;
            }
        }

        public virtual async Task<bool> Update(TEntity entity)
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));
            try
            {
                dbSet.Update(entity);

                return true;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public virtual async Task<TEntity> GetById(Guid ID)
        {
            try
            {
                return await dbSet.FindAsync(ID);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public virtual async Task<IEnumerable<TEntity>> GetAll()
        {
            try
            {
                return dbSet;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public virtual async Task<IEnumerable<TEntity>> GetMany(System.Linq.Expressions.Expression<Func<TEntity, bool>> where)
        {
            return dbSet.Where(where);
        }

        public virtual async Task<int> Count()
        {
            return await dbSet.CountAsync();
        }

        public virtual async Task<int> Count(System.Linq.Expressions.Expression<Func<TEntity, bool>> where)
        {
            return await dbSet.CountAsync(where);
        }
    }
}