using ERP.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ERP.Core.Repositories
{
    public interface IGenericRepository<T> where T : class
    {
        Task<OperationResult<T>> GetByIdAsync(string id);
        IQueryable<T> GetAll();
        IQueryable<T> Where(Expression<Func<T, bool>> expression);
        Task<OperationResult<bool>> AnyAsync(Expression<Func<T, bool>> expression);
        Task<OperationResult> AddAsync(T entity);
        Task<OperationResult> AddRangeAsync(IEnumerable<T> entities);
        Task<OperationResult> UpdateAsync(T entity);
        Task<OperationResult> UpdateRangeAsync(IEnumerable<T> entities);
        Task<OperationResult> RemoveAsync(T entity);
        Task<OperationResult> RemoveRangeAsync(IEnumerable<T> entities);
        IQueryable<string> SelectString(Expression<Func<T, string>> expression);
    }
}
