using CA.Core.Application.Services.IServices.Base;
using CA.Core.Application.DTOs;

namespace CA.Core.Application.Services.IServices
{
    public interface IUserService : IService<UserDTO>
    {
        Task<string> GetFirstNameAndLastName(Guid ID);
    }
}