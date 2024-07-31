using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.Core.UnitOfWorks
{
    public interface IUnitOfWork
    {
        Task<bool> CommitAsync();
        Task<bool> CommitTransactionAsync();
        bool Commit();
        Task BeginTransactionAsync();
        Task RollbackAsync();
    }
}
