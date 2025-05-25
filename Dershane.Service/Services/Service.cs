using System.Linq.Expressions;
using Dershane.Core.Services;
using Dershane.Core.Repositories;
using Microsoft.EntityFrameworkCore.Query;
using Dershane.Core.UnitOfWorks;
using Dershane.Core.Exceptions;

namespace Dershane.Service.Services
{
    public class Service<T> : IService<T> where T : class
    {
        private readonly IGenericRepository<T> _repository;
        private readonly IUnitOfWork _unitOfWork;

        public Service(IGenericRepository<T> repository, IUnitOfWork unitOfWork)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
        }

        public async Task<T> AddAsync(T entity)
        {
            await _repository.AddAsync(entity);
            return entity;
        }

        public async Task<IEnumerable<T>> AddRangeAsync(IEnumerable<T> entities)
        {
            await _repository.AddRangeAsync(entities);
            return entities;
        }

        public Task<bool> AnyAsync(Expression<Func<T, bool>> expression)
        {
            return _repository.AnyAsync(expression);
        }

        public async Task<T> FirstOrDefaultAsync(Expression<Func<T, bool>> expression, string[] includes = null, params Expression<Func<T, object>>[] includeExpressions)
        {
            return await _repository.FirstOrDefaultAsync(expression, includes, includeExpressions);
        }

        public async Task<IEnumerable<T>> GetAllAsync(int? pageNumber = null, int? pageSize = null)
        {
            return await _repository.GetAllAsync(pageNumber, pageSize);
        }

        public async Task<T> GetByGuidIdAsync(Guid id)
        {
            var model = await _repository.GetByGuidIdAsync(id);
            if (model == null)
            {
                throw new NotFoundException($"{id} id li {typeof(T).Name}  bulunamadı.");
            }
            return model;
        }

        public async Task<T> GetByIdAsync(int id)
        {
            var model = await _repository.GetByIdAsync(id);
            if (model == null)
            {
                throw new NotFoundException($"{id} id li {typeof(T).Name}  bulunamadı.");
            }
            return model;
        }

        public async Task<T> GetByIdAsync(byte id)
        {
            var model = await _repository.GetByIdAsync(id);
            if (model == null)
            {
                throw new NotFoundException($"{id} id li {typeof(T).Name}  bulunamadı.");
            }
            return model;
        }

        public IQueryable<T> GetList(Expression<Func<T, bool>> expression, string[] includes = null, bool asNoTracking = true, params Expression<Func<T, object>>[] includeExpressions)
        {
            return _repository.GetList(expression, includes, asNoTracking, includeExpressions);
        }

        public Task RemoveAsync(T entity)
        {
            _repository.Remove(entity);
            return Task.CompletedTask;
        }

        public Task RemoveRangeAsync(IEnumerable<T> entities)
        {
            _repository.RemoveRange(entities);
            return Task.CompletedTask;
        }

        public async Task<T> SingleOrDefaultAsync(Expression<Func<T, bool>> expression, string[] includes = null)
        {
            var model = await _repository.SingleOrDefaultAsync(expression, includes);
            if (model == null)
            {
                throw new NotFoundException($"{typeof(T).Name}  bulunamadı.");
            }
            return model;
        }

        public Task UpdateAsync(T entity)
        {
            _repository.Update(entity);
            return Task.CompletedTask;
        }
        public async Task BulkDeleteAsync(Expression<Func<T, bool>> query)
        {
            await _repository.BulkDeleteAsync(query);
        }

        public async Task BulkUpdateAsync(Expression<Func<T, bool>> query, Expression<Func<SetPropertyCalls<T>, SetPropertyCalls<T>>> expression)
        {
            await _repository.BulkUpdateAsync(query, expression);
        }
    }

}
