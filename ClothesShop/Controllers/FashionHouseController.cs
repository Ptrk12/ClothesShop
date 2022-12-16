using ClothesShop.Data;
using ClothesShop.Data.Services;
using ClothesShop.Data.Static;
using ClothesShop.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ClothesShop.Controllers
{
    [Authorize(Roles = UserRoles.Admin)]
    public class FashionHouseController : Controller
    {
        private readonly IFashionHouseService _service;

        public FashionHouseController(IFashionHouseService service)
        {
            _service = service;
        }

        [AllowAnonymous]
        public async Task<IActionResult> Index()
        {
            var data = await _service.GetAllAsync(); 
            return View(data);
        }

        [AllowAnonymous]
        public async Task<IActionResult> Details(int id)
        {
            var item = await _service.GetByIdAsync(id);
            if (item == null)
            {
                return View("NotFound");
            }
            return View(item);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create([Bind("ProfilePictureUrl, FullName, Bio")] FashionHouse fashionHouse)
        {
            if (!ModelState.IsValid)
            {
                return View(fashionHouse);
            }
            await _service.AddAsync(fashionHouse);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Edit(int id)
        {
            var item = await _service.GetByIdAsync(id);
            if(item==null)
            {
                return View("NotFound");
            }
            return View(item);
        }
        [HttpPost]
        public async Task<IActionResult> Edit([Bind("Id,ProfilePictureUrl,FullName,Bio")]int id,  FashionHouse fashionHouse)
        {
            if (!ModelState.IsValid)
            {
                return View(fashionHouse);
            }
            if (id == fashionHouse.Id)
            {
                await _service.UpdateAsync(id, fashionHouse);
                return RedirectToAction(nameof(Index));
            }
            return View(fashionHouse);
        }

        public async Task<IActionResult> Delete(int id)
        {
            var item = await _service.GetByIdAsync(id);
            if (item == null)
            {
                return View("NotFound");
            }
            return View(item);
        }
        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var item = await _service.GetByIdAsync(id);
            if (item == null)
            {
                return View("NotFound");
            }
            await _service.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }


    }
}
