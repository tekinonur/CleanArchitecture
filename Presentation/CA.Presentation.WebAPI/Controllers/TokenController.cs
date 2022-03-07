using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CA.Core.Application.DTOs.User;
using CA.Infrastructure.Identity;
using Microsoft.AspNetCore.Mvc;

namespace CA.Presentation.WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TokenController : ControllerBase
    {
        private readonly ILogger<ItemController> _logger;
        private readonly ITokenService _tokenService;

        public TokenController(
            ILogger<ItemController> logger,
            ITokenService tokenService
        )
        {
            _logger = logger;
            _tokenService = tokenService;
        }
        
        [HttpPost("auth")]
        public IActionResult Authenticate([FromBody]AuthenticationRequest model)
        {
            var response = _tokenService.Authenticate(model);

            if (response == null)
                return BadRequest(new
                {
                    message = "Email or password is wrong!"
                });

            return Ok(response);
        }
    }
}