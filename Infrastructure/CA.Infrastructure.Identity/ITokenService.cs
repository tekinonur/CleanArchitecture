using CA.Core.Application.DTOs;
using CA.Core.Application.DTOs.User;

namespace CA.Infrastructure.Identity
{
    public interface ITokenService
    {
         Task<AuthenticationResponse> Authenticate(AuthenticationRequest model);
         string GenerateJwtToken(UserDTO user);
    }
}