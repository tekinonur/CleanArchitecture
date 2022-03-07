using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CA.Core.Application.DTOs.User
{
  public class AuthenticationResponse : UserDTO
    {
        public string Token { get; set; }
        public AuthenticationResponse(UserDTO userDTO, string token)
        {
            ID = userDTO.ID;
            FirstName = userDTO.FirstName ;
            LastName = userDTO.LastName;
            Email = userDTO.Email;
            Token = token;
        }
    }
}