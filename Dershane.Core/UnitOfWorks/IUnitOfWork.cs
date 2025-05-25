using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dershane.Core.Repositories;

namespace Dershane.Core.UnitOfWorks
{
    public interface IUnitOfWork
    {
        Task CommitAsync();
        void Commit();
        IGenericRepository<T> GenericRepository<T>() where T : class;
    }
}
