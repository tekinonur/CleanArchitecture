using CA.Core.Application.Services.IServices.Base;
using CA.Core.Application.DTOs;
using CA.Core.Application.DTOs.User;

namespace CA.Core.Application.Services.IServices
{
    public interface IUserService : IService<UserDTO>
    {
        Task<string> GetFirstNameAndLastName(Guid ID);
    }
}