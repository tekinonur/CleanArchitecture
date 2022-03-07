using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using CA.Core.Application.DTOs;
using CA.Core.Application.DTOs.User;
using CA.Core.Domain.Entities;
using CA.Core.Domain.IRepositories.Base;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace CA.Infrastructure.Identity
{
    public class TokenService : ITokenService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly AuthenticationSettings _authSettings;

        public TokenService(
            IUnitOfWork unitOfWork,
            IMapper mapper,
            IOptions<AuthenticationSettings> appSettings
        )
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _authSettings = appSettings.Value;
        }

        public async Task<AuthenticationResponse> Authenticate(AuthenticationRequest model)
        {
            var user = await _unitOfWork.Users.GetUserByEmailAndPassword(model.Email, model.Password);
            if (user == null)
                return null;

            UserDTO userDTO = _mapper.Map<UserDTO>(user);

            var token = GenerateJwtToken(userDTO);

            return new AuthenticationResponse(userDTO, token);
        }

        public string GenerateJwtToken(UserDTO user)
        {
                      // 1 saat süreyle geçerli olacak bir token üretiliyor
            var key = Encoding.ASCII.GetBytes(_authSettings.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[] {
                    new Claim("userId", user.ID.ToString()),
                    new Claim("email",user.Email)
                }),
                Expires = DateTime.UtcNow.AddHours(1),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}