using Microsoft.AspNetCore.Mvc;
using CA.Core.Application.Services.IServices;
using CA.Core.Application.DTOs;
using CA.Infrastructure.Identity;

namespace CA.Presentation.WebAPI.Controllers
{   
    [Authorize] 
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

        /// <summary>
        /// Tüm Itemleri getirir
        /// </summary>
        /// <returns></returns>
        [HttpGet("GetAllItems")]
        public async Task<IActionResult> GetAllItems()
        {
            var items = await _itemService.GetAll();
            return Ok(items);
        }

        /// <summary>
        /// ID ye göre Item getirir
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        [HttpGet("GetItemByID{ID:Guid}")]
        public async Task<IActionResult> GetItemByID(Guid ID)
        {
            return Ok(await _itemService.GetById(ID));
        }

        /// <summary>
        /// Yeni Item ekler. ID yi otomatik verir
        /// </summary>
        /// <param name="itemDTO"></param>
        /// <returns></returns>
        [HttpPut("CreateItem")]
        public async Task<IActionResult> CreateItem(ItemDTO itemDTO)
        {
            if(ModelState.IsValid)
            {
                itemDTO.ID = Guid.NewGuid();    
                await _itemService.Add(itemDTO);

                return CreatedAtAction("GetItemByID",new {itemDTO.ID}, itemDTO);
            }

            return new JsonResult("Something went wrong") { StatusCode = 500 };
        }

        /// <summary>
        /// Item günceller
        /// </summary>
        /// <param name="ID"></param>
        /// <param name="itemDTO"></param>
        /// <returns></returns>
        [HttpPost("{ID}")]
        public async Task<IActionResult> UpdateItem(Guid ID,ItemDTO itemDTO)
        {
            if(ID != itemDTO.ID)
                return BadRequest();

            await _itemService.Update(itemDTO);
            
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
            var item = await _itemService.GetById(ID);
            
            if(item == null)
                return BadRequest();

            await _itemService.Delete(ID);

            return Ok(item);        
        }
    }
}