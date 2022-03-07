using Microsoft.AspNetCore.Mvc;
using CA.Core.Application.Services.IServices;

namespace CA.Presentation.WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ItemController : ControllerBase
    {
        private readonly ILogger<ItemController> _logger;
        private readonly IItemService _itemService;

        public ItemController(
            ILogger<ItemController> logger,
            IItemService itemService
        )
        {
            _logger = logger;
            _itemService = itemService;
        }

        [HttpGet("GetAllItems")]
        public async Task<IActionResult> GetAllItems()
        {
            var items = await _itemService.GetAll();
            return Ok(items);
        }

        [HttpGet("GetItemByID{ID:Guid}")]
        public async Task<IActionResult> GetItemByID(Guid ID)
        {
            return Ok(await _itemService.GetById(ID));
        }
    }
}