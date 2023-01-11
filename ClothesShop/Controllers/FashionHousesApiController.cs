using ClothesShop.Data.Services;
using ClothesShop.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ClothesShop.Controllers
{
    [Route("api/fashionhouses")]
    [ApiController]
    public class FashionHousesApiController : ControllerBase
    {
        private readonly IFashionHouseService _service;

        public FashionHousesApiController(IFashionHouseService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var result = await _service.GetAllAsync();
            return Ok(result);
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var result = await _service.GetByIdAsync(id);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var isUpdated = await _service.DeleteAsync(id);
            if (isUpdated)
            {
                return Ok();
            }
            return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] FashionHouse fashionHouse)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            await _service.AddAsync(fashionHouse);
            return Created($"/api/fashionHouse/{fashionHouse.Id}", fashionHouse);
        }

        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] FashionHouse fashionHouse)
        {
            var found = await _service.GetByIdAsync(id);
            if (found == null)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                await _service.UpdateAsync(id, fashionHouse);
                return Ok();
            }
            return BadRequest();
        }
    }
}

