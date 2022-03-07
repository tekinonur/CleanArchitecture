using CA.Core.Domain.Entities;
using CA.Core.Domain.IRepositories.Base;

namespace CA.Core.Domain.IRepositories
{
    public interface IUserRepository : IRepository<User>
    {
        Task<string> GetFirstNameAndLastName(Guid ID);
        Task<User> GetUserByEmailAndPassword(string email, string password);
    }
}