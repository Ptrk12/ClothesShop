using ClothesShop.Data.Services;
using ClothesShop.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ClothesShop.Controllers
{
    [Route("api/designer")]
    [ApiController]
    public class DesignerApiController : ControllerBase
    {
        private readonly IDesignerService _service;

        public DesignerApiController(IDesignerService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult<Designer>> Get()
        {
            var result = await _service.GetAllAsync();
            return Ok(result);
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<ActionResult<Designer>> Get(int id)
        {
            if(id == null)
            {
                return BadRequest();
            }
            var result = await _service.GetByIdAsync(id);
            if(result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            if(id == null)
            {
                return BadRequest();
            }
            var result = await _service.GetByIdAsync(id);
            if(result != null)
            {
                await _service.DeleteAsync(id);
                return Ok();
            }
            return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Designer designer)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest();
            }
            await _service.AddAsync(designer);
            return Created($"/api/book/{designer.Id}", designer);
        }

        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> Update([FromRoute]int id,[FromBody]Designer designer)
        {
            var foundDesigner = await _service.GetByIdAsync(id);
            if (foundDesigner == null)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                await _service.UpdateAsync(id, designer);
                return Ok();
            }
            return BadRequest();
        }
    }
}
