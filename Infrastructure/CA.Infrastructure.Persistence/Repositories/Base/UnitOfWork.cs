using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CA.Core.Domain.IRepositories;
using CA.Core.Domain.IRepositories.Base;

namespace CA.Infrastructure.Persistence.Repositories.Base
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;

        public IUserRepository Users { get; private set; }

        public UnitOfWork(
            ApplicationDbContext context
        )
        {
            _context = context;

            Users = new UserRepository(_context);
        }

        public Task CompleteAsync()
        {
            throw new NotImplementedException();
        }
    }
}