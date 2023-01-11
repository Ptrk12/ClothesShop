using ClothesShop.Data.Services;
using ClothesShop.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ClothesShop.Controllers
{
    [Route("api/clothes")]
    [ApiController]
    public class ClothesApiController : ControllerBase
    {
        private readonly IClothesService _service;

        public ClothesApiController(IClothesService service)
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
            var result = await _service.GetByIdAsync(id);
            if (result != null)
            {
                await _service.DeleteAsync(id);
                return Ok();
            }
            return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] NewClothesVm clothes)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            await _service.AddNewClothes(clothes);
            return Created($"/api/book/{clothes.Id}", clothes);
        }

        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] NewClothesVm clothes)
        {
            var found = await _service.GetByIdAsync(id);
            if (found == null)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                await _service.UpdateClothesAsync(clothes);
                return Ok();
            }
            return BadRequest();
        }
    }
}
