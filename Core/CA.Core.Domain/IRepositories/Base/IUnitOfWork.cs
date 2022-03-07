using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CA.Core.Domain.IRepositories.Base
{
    public interface IUnitOfWork
    {
        IUserRepository Users { get; }
        IItemRepository Items { get; }

        Task<int> CompleteAsync();
    }
}