using ClothesShop.Data;
using ClothesShop.Data.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ClothesShop.Controllers
{
    public class ClothesController : Controller
    {
        private readonly IClothesService _service;

        public ClothesController(IClothesService service)
        {
            _service = service;
        }

        public async Task<IActionResult> Index()
        {
            var data = await _service.GetAllAsync();
            return View(data);
        }

        public async Task<IActionResult> Details(int id)
        {
            var item = await _service.GetClothesByIdAsync(id);
            return View(item);
        }
        public IActionResult Create()
        {
            ViewData["Welcome"] = "Welcome to our store";
            ViewBag.Description = "This is the store description";
            return View();
        }

    }
}
