using Microsoft.AspNetCore.Mvc;
using CA.Core.Application.Services.IServices;
using CA.Core.Application.DTOs;

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

        /// <summary>
        /// Tüm kullanıcıları getirir
        /// </summary>
        /// <returns></returns>
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

        /// <summary>
        /// Yeni Item ekler. ID yi otomatik verir
        /// </summary>
        /// <param name="userDTO"></param>
        /// <returns></returns>
        [HttpPut("CreateUser")]
        public async Task<IActionResult> CreateUser(UserDTO userDTO)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    userDTO.ID = Guid.NewGuid();
                    userDTO.CreatedOn = DateTime.Now;

                    await _userService.Add(userDTO);

                    return CreatedAtAction("GetItemByID", new { userDTO.ID }, userDTO);
                }

                return new JsonResult("Something went wrong") { StatusCode = 500 };
            }
            catch (Exception ex)
            {
                _logger.LogError("CreateUser",ex);
                return new JsonResult("Something went wrong") { StatusCode = 500 };
            }
        }

        /// <summary>
        /// Item günceller
        /// </summary>
        /// <param name="ID"></param>
        /// <param name="userDTO"></param>
        /// <returns></returns>
        [HttpPost("{ID}")]
        public async Task<IActionResult> UpdateItem(Guid ID, UserDTO userDTO)
        {
            if (ID != userDTO.ID)
                return BadRequest();

            userDTO.UpdatedOn = DateTime.Now;
            await _userService.Update(userDTO);

            return NoContent();
        }

        /// <summary>
        /// Item siler
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        [HttpDelete("{ID}")]
        public async Task<IActionResult> DeleteItem(Guid ID)
        {
            var item = await _userService.GetById(ID);

            if (item == null)
                return BadRequest();

            await _userService.Delete(ID);

            return Ok(item);
        }
    }
}