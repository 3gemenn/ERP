using ERP.Core.Repositories;
using ERP.Repository.ProjectDbContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ERP.Repository.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        protected readonly AppDbContext _context;
        private readonly DbSet<T> _dbSet;
        private readonly ILogger<GenericRepository<T>> _logger;

        public GenericRepository(AppDbContext context, ILogger<GenericRepository<T>> logger)
        {
            _context = context;
            _dbSet = _context.Set<T>();
            _logger = logger;
        }

        public async Task<OperationResult> AddAsync(T entity)
        {
            try
            {
                await _dbSet.AddAsync(entity);
                int affectedRows = await _context.SaveChangesAsync();
                return new OperationResult
                {
                    Success = affectedRows > 0,
                    Message = affectedRows > 0 ? "Entity added successfully." : "Failed to add entity.",
                    AffectedRows = affectedRows
                };
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error adding entity: {ex.Message}");
                return new OperationResult
                {
                    Success = false,
                    Message = $"Failed to add entity: {ex.Message}",
                    AffectedRows = 0
                };
            }
        }

        public async Task<OperationResult> AddRangeAsync(IEnumerable<T> entities)
        {
            try
            {
                await _dbSet.AddRangeAsync(entities);
                int affectedRows = await _context.SaveChangesAsync();
                return new OperationResult
                {
                    Success = affectedRows > 0,
                    Message = affectedRows > 0 ? "Entities added successfully." : "Failed to add entities.",
                    AffectedRows = affectedRows
                };
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error adding entities: {ex.Message}");
                return new OperationResult
                {
                    Success = false,
                    Message = $"Failed to add entities: {ex.Message}",
                    AffectedRows = 0
                };
            }
        }

        public async Task<OperationResult> RemoveAsync(T entity)
        {
            try
            {
                _dbSet.Remove(entity);
                int affectedRows = await _context.SaveChangesAsync();
                return new OperationResult
                {
                    Success = affectedRows > 0,
                    Message = affectedRows > 0 ? "Entity removed successfully." : "Failed to remove entity.",
                    AffectedRows = affectedRows
                };
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error removing entity: {ex.Message}");
                return new OperationResult
                {
                    Success = false,
                    Message = $"Failed to remove entity: {ex.Message}",
                    AffectedRows = 0
                };
            }
        }

        public async Task<OperationResult> RemoveRangeAsync(IEnumerable<T> entities)
        {
            try
            {
                _dbSet.RemoveRange(entities);
                int affectedRows = await _context.SaveChangesAsync();
                return new OperationResult
                {
                    Success = affectedRows > 0,
                    Message = affectedRows > 0 ? "Entities removed successfully." : "Failed to remove entities.",
                    AffectedRows = affectedRows
                };
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error removing entities: {ex.Message}");
                return new OperationResult
                {
                    Success = false,
                    Message = $"Failed to remove entities: {ex.Message}",
                    AffectedRows = 0
                };
            }
        }

        public async Task<OperationResult> UpdateAsync(T entity)
        {
            try
            {
                _context.Entry(entity).State = EntityState.Modified;
                int affectedRows = await _context.SaveChangesAsync();
                return new OperationResult
                {
                    Success = affectedRows > 0,
                    Message = affectedRows > 0 ? "Entity updated successfully." : "Failed to update entity.",
                    AffectedRows = affectedRows
                };
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error updating entity: {ex.Message}");
                return new OperationResult
                {
                    Success = false,
                    Message = $"Failed to update entity: {ex.Message}",
                    AffectedRows = 0
                };
            }
        }
        public async Task<OperationResult> UpdateRangeAsync(IEnumerable<T> entities)
        {
            try
            {
                _context.UpdateRange(entities);
                int affectedRows = await _context.SaveChangesAsync();
                return new OperationResult
                {
                    Success = affectedRows > 0,
                    Message = affectedRows > 0 ? "Entities updated successfully." : "Failed to update entities.",
                    AffectedRows = affectedRows
                };
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error updating entities: {ex.Message}");
                return new OperationResult
                {
                    Success = false,
                    Message = $"Failed to update entities: {ex.Message}",
                    AffectedRows = 0
                };
            }
        }

        public async Task<OperationResult<T>> GetByIdAsync(string id)
        {
            try
            {
                var entity = await _dbSet.FindAsync(id);
                if (entity != null)
                {
                    _context.Entry(entity).State = EntityState.Detached;
                }

                return new OperationResult<T>
                {
                    Success = entity != null,
                    Message = entity != null ? "Entity retrieved successfully." : "Entity not found.",
                    Data = entity
                };
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error retrieving entity: {ex.Message}");
                return new OperationResult<T>
                {
                    Success = false,
                    Message = $"Failed to retrieve entity: {ex.Message}",
                    Data = null
                };
            }
        }

        public IQueryable<T> GetAll()
        {
            return _dbSet.AsNoTracking().AsQueryable();
        }

        public async Task<OperationResult<bool>> AnyAsync(Expression<Func<T, bool>> expression)
        {
            try
            {
                var result = await _dbSet.AnyAsync(expression);
                return new OperationResult<bool>
                {
                    Success = true,
                    Message = "Query executed successfully.",
                    Data = result
                };
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error executing query: {ex.Message}");
                return new OperationResult<bool>
                {
                    Success = false,
                    Message = $"Failed to execute query: {ex.Message}",
                    Data = false
                };
            }
        }

        public IQueryable<T> Where(Expression<Func<T, bool>> expression)
        {
            return _dbSet.Where(expression);
        }

        public IQueryable<string> SelectString(Expression<Func<T, string>> expression)
        {
            return _dbSet.Select(expression);
        }
    }
}
