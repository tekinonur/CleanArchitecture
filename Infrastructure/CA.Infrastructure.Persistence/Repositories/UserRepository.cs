using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CA.Core.Application.Repositories;
using CA.Core.Domain.Entities;
using CA.Infrastructure.Persistence.Repositories.Base;

namespace CA.Infrastructure.Persistence.Repositories
{
    public class UserRepository  : Repository<User>, IUserRepository
    {
        public UserRepository(
            ApplicationDbContext context
        ) : base(context)
        {

        }

        public async Task<string> GetFirstNameAndLastName(Guid ID)
        {
            try
            {
                var user = await dbSet.FindAsync(ID);
                if(user == null){
                    throw new ArgumentNullException(nameof(user));
                }

                return user.FirstName + " " + user.LastName;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}