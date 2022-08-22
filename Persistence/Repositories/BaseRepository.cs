using Application.Interfaces.Repository;
using Domain.Common;
using Microsoft.EntityFrameworkCore;
using Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Repositories
{
    public class BaseRepository<T> : IBaseRepository<T> where T : BaseEntity, new()
    {
        private readonly DbContext _context;
        private readonly DbSet<T> _dbSet;
        public DbContext CurrentContext => _context;

        public BaseRepository(DbContext dbContext)
        {
            _context = dbContext;
            _dbSet = _context.Set<T>();
        }

        public async Task AddAsync(T entity)
        {
            await _dbSet.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task AddRangeAsync(ICollection<T> entities)
        {
            await _dbSet.AddRangeAsync(entities);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(T entity)
        {
            //_context.Entry(entity).State = EntityState.Deleted;
            //await _context.SaveChangesAsync();
            if (entity.IsDeleted == false)
            {
                entity.IsDeleted = true;
                _dbSet.Update(entity);
                await _context.SaveChangesAsync();
            }
        }

        public async Task DeleteRangeAsync(ICollection<T> entities)
        {
            _context.RemoveRange(entities);
            await _context.SaveChangesAsync();
        }

        public async Task<T> GetAsync(Expression<Func<T, bool>> where)
        {
            return await _dbSet.AsNoTracking().Where(t => t.IsDeleted == false).SingleOrDefaultAsync(where);
        }

        public async Task<T> GetByIdAsync(string id)
        {
            var entity = await _dbSet.Where(t => t.IsDeleted == false).SingleOrDefaultAsync(e => e.Id == id);
            if (entity == null)
                throw new ArgumentNullException("Entity doesn't exist.");
            _context.Entry(entity).State = EntityState.Detached;
            return entity;
        }

        public async Task<ICollection<T>> GetListAsync()
        {
            //return await GetListAsync(filter, null, 0, int.MaxValue);
            return await _dbSet.AsNoTracking().Where(t => t.IsDeleted == false).ToListAsync();
        }
        public async Task<ICollection<T>> GetListAsync(
            Expression<Func<T, bool>> filter = null,
            Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
            int skip = 0, int take = int.MaxValue,
            params Expression<Func<T, object>>[] includes)
        {
            IQueryable<T> query = _dbSet;

            if (includes != null && includes.Length > 0)
                foreach (Expression<Func<T, object>> include in includes)
                    query = query.Include(include);

            if (filter != null)
                query = query.Where(filter);

            if (orderBy != null)
                query = orderBy(query);

            query = query.Skip(skip).Take(take);

            return await query.AsNoTracking().ToListAsync();

        }

        public async Task UpdateAsync(T entity)
        {
            _dbSet.Update(entity);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateRangeAsync(ICollection<T> entities)
        {
            _dbSet.UpdateRange(entities);
            await _context.SaveChangesAsync();
        }
    }
}
