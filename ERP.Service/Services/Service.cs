using ERP.Core.Repositories;
using ERP.Core.Services;
using ERP.Core.UnitOfWorks;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ERP.Service.Services
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


        public async Task<OperationResult> AddAsync(T entity)
        {
            var result = await _repository.AddAsync(entity);
            if (result.Success)
            {
                await _unitOfWork.CommitAsync();
                return result;
            }
            else
            {
                return result;
            }

        }

        public async Task<OperationResult> AddRangeAsync(IEnumerable<T> entities)
        {
            var result = await _repository.AddRangeAsync(entities);
            if (result.Success)
            {
                await _unitOfWork.CommitAsync();
                return result;
            }
            else { return result; }

        }

        public async Task<OperationResult<bool>> AnyAsync(Expression<Func<T, bool>> expression)
        {
            return await _repository.AnyAsync(expression);
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _repository.GetAll().ToListAsync();
        }

        public async Task<OperationResult<T>> GetByIdAsync(string id)
        {
            var hasProduct = await _repository.GetByIdAsync(id);

            return hasProduct;
        }

        public async Task<OperationResult> RemoveAsync(T entity)
        {
            var result = await _repository.RemoveAsync(entity);
            if (result.Success)
            {
                _unitOfWork.Commit();
                return result;
            }
            else
            {
                return result;
            }

        }

        public async Task<OperationResult> RemoveRangeAsync(IEnumerable<T> entities)
        {
            var result = await _repository.RemoveRangeAsync(entities);
            if (!result.Success)
            {
                await _unitOfWork.CommitAsync();
                return result;
            }
            else
            {
                return result;
            }

        }

        public async Task<OperationResult> UpdateAsync(T entity)
        {
            var result = await _repository.UpdateAsync(entity);
            if (result.Success)
            {

                _unitOfWork.Commit();
                return result;
            }
            else
            {
                return result;
            }
        }


        public IQueryable<T> Where(Expression<Func<T, bool>> expression)
        {
            return _repository.Where(expression);
        }
    }
}
