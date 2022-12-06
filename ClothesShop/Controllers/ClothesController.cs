using ClothesShop.Data;
using ClothesShop.Data.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
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
        public async Task<IActionResult> Create()
        {
            var dropDownData = await _service.GetNewClothesDropDowns();
            ViewBag.FashionHouse = new SelectList(dropDownData.FashionHouses,"Id","FullName");
            ViewBag.Designers = new SelectList(dropDownData.Designers,"Id","FullName");
            return View();
        }

    }
}
