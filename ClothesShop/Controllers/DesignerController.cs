using ClothesShop.Data;
using ClothesShop.Data.Services;
using ClothesShop.Data.Static;
using ClothesShop.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ClothesShop.Controllers
{
    [Authorize(Roles =UserRoles.Admin)]
    public class DesignerController : Controller
    {
        private readonly IDesignerService _service;

        public DesignerController(IDesignerService service)
        {
            _service = service;
        }

        [AllowAnonymous]
        public async Task<IActionResult> Index()
        {
            var data = await _service.GetAllAsync();
            return View(data);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create([Bind("FullName,ProfilePictureUrl,Bio")] Designer designer)
        {

            if (ModelState.IsValid)
            {
                await _service.AddAsync(designer);
                return RedirectToAction(nameof(Index));

            }
            return View();
            
        }
        [AllowAnonymous]
        public async Task<IActionResult> Details(int id)
        {
            var designer = await _service.GetByIdAsync(id);
            if(designer == null)
            {
                return View("NotFound");
            }
            return View(designer);
        }

        public async Task<IActionResult> Edit(int id)
        {
            var designer = await _service.GetByIdAsync(id);
            if (designer == null)
            {
                return View("NotFound");
            }
            return View(designer);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(int id,[Bind("Id,FullName,ProfilePictureUrl,Bio")] Designer designer)
        {

            if (ModelState.IsValid)
            {
                await _service.UpdateAsync(id, designer);
                return RedirectToAction(nameof(Index));

            }
            return View();

        }

        public async Task<IActionResult> Delete(int id)
        {
            var designer = await _service.GetByIdAsync(id);
            if (designer == null)
            {
                return View("NotFound");
            }
            return View(designer);
        }
        [HttpPost]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var designer = _service.GetByIdAsync(id);
            if (designer == null)
            {
                return View("NotFound");
            }
            await _service.DeleteAsync(id);
            return RedirectToAction(nameof(Index));

        }

    }
}
