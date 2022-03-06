using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CA.Core.Domain.Entities;
using CA.Core.Application.Repositories.Base;

namespace CA.Core.Application.Repositories
{
    public interface IUserRepository : IRepository<User>
    {
        Task<string> GetFirstNameAndLastName(Guid ID);
    }
}