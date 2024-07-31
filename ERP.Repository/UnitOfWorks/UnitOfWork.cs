using ERP.Core.UnitOfWorks;
using ERP.Repository.ProjectDbContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.Repository.UnitOfWorks
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _context;

        public UnitOfWork(AppDbContext context)
        {
            _context = context;
        }

        public async Task BeginTransactionAsync()
        {
            await _context.Database.BeginTransactionAsync();
        }

        public bool Commit()
        {
            var a = _context.SaveChanges();
            //_context.Database.CurrentTransaction.Commit();
            return true;
        }

        public async Task<bool> CommitAsync()
        {
            var a = await _context.SaveChangesAsync();
            // await _context.Database.CurrentTransaction.CommitAsync();
            return true;
        }
        public async Task<bool> CommitTransactionAsync()
        {
            var a = await _context.SaveChangesAsync();
            await _context.Database.CurrentTransaction.CommitAsync();
            return true;
        }

        public async Task RollbackAsync()
        {
            await _context.Database.CurrentTransaction.RollbackAsync();
        }
    }
}
