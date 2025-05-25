using System.Linq.Expressions;
using Dershane.Core.Context;
using Dershane.Core.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;

namespace Dershane.Repository.Repositories

{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        protected readonly ApplicationDbContext _context;
        private readonly DbSet<T> _dbSet;
        public GenericRepository(ApplicationDbContext context)
        {
            _context = context;
            _dbSet = _context.Set<T>();
        }
        public async Task AddAsync(T entity)
        {
            await _dbSet.AddAsync(entity);
        }

        public async Task AddRangeAsync(IEnumerable<T> entities)
        {
            await _dbSet.AddRangeAsync(entities);
        }

        public async Task<bool> AnyAsync(Expression<Func<T, bool>> expression)
        {
            return await _dbSet.AnyAsync(expression);
        }

        public async Task<T> FirstOrDefaultAsync(Expression<Func<T, bool>> expression, string[] includes = null, params Expression<Func<T, object>>[] includeExpressions)
        {
            var sorgu = _dbSet.AsQueryable();
            if (includes != null)
            {
                foreach (var include in includes)
                    sorgu = sorgu.Include(include);
            }
            if (includeExpressions.Count() > 0)
            {
                foreach (var include in includeExpressions)
                    sorgu = sorgu.Include(include);
            }
            return await sorgu.FirstOrDefaultAsync(expression);
        }

        public async Task<IEnumerable<T>> GetAllAsync(int? pageNumber = null, int? pageSize = null)
        {
            return await _dbSet.AsSplitQuery().IgnoreAutoIncludes().AsNoTracking().ToListAsync();
        }

        public async Task<T> GetByGuidIdAsync(Guid id)
        {
            return await _dbSet.FindAsync(id);
        }

        public async Task<T> GetByIdAsync(int id)
        {
            return await _dbSet.FindAsync(id);
        }
        public async Task<T> GetByIdAsync(byte id)
        {
            return await _dbSet.FindAsync(id);
        }
        public IQueryable<T> GetList(Expression<Func<T, bool>> expression, string[] includes = null, bool asNoTracking = true, params Expression<Func<T, object>>[] includeExpressions)
        {
            var sorgu = _dbSet.IgnoreAutoIncludes().AsSplitQuery().AsQueryable();
            if (includes != null)
            {
                foreach (var include in includes)
                    sorgu = sorgu.Include(include);
            }
            if (includeExpressions.Count() > 0)
            {
                foreach (var include in includeExpressions)
                    sorgu = sorgu.Include(include);
            }
            sorgu = sorgu.Where(expression);


            return asNoTracking ? sorgu.AsNoTracking() : sorgu; ;
        }
        public void Remove(T entity)
        {
            _dbSet.Remove(entity);
        }

        public void RemoveRange(IEnumerable<T> entities)
        {
            _dbSet.RemoveRange(entities);
        }

        public async Task<T> SingleOrDefaultAsync(Expression<Func<T, bool>> expression, string[] includes = null)
        {
            var sorgu = _dbSet.AsQueryable();
            if (includes != null)
            {
                foreach (var include in includes)
                    sorgu = sorgu.Include(include);
            }
            return await sorgu.SingleOrDefaultAsync(expression);
        }

        public void Update(T entity)
        {
            _context.Entry<T>(entity).State = EntityState.Modified;
            _dbSet.Update(entity);
        }
        public async Task BulkDeleteAsync(Expression<Func<T, bool>> query)
        {
            await _dbSet.Where(query).ExecuteDeleteAsync();
        }
        /// <summary>
        /// Toplu Update 31.10.2024
        /// </summary>
        /// <param name="query"> where sorgusu</param>
        /// <param name="expression"> yeni atanacak değerler</param>
        /// <returns></returns>
        public async Task BulkUpdateAsync(Expression<Func<T, bool>> query, Expression<Func<SetPropertyCalls<T>, SetPropertyCalls<T>>> expression)
        {
            await _dbSet.Where(query).ExecuteUpdateAsync(expression);
        }
    }
}
