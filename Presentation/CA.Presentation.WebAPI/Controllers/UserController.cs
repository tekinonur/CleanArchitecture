using Microsoft.AspNetCore.Mvc;
using CA.Core.Application.Services.IServices;

namespace CA.Presentation.WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly ILogger<UserController> _logger;
        private readonly IUserService _userService;

        public UserController(
            ILogger<UserController> logger,
            IUserService userService
        )
        {
            _logger = logger;
            _userService = userService;
        }

        [HttpGet("GetAllUsers")]
        public async Task<IActionResult> GetAllUsers()
        {
            var items = await _userService.GetAll();
            return Ok(items);
        }

        [HttpGet("GetUserByID{ID:Guid}")]
        public async Task<IActionResult> GetUserByID(Guid ID)
        {
            return Ok(await _userService.GetById(ID));
        }
    }
}