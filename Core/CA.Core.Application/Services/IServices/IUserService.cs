using CA.Core.Application.Services.IServices.Base;
using CA.Core.Domain.Entities;

namespace CA.Core.Application.Services.IServices
{
    public interface IUserService : IService<User>
    {
        Task<string> GetFirstNameAndLastName(Guid ID);
    }
}