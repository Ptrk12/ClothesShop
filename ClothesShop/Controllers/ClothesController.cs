using ClothesShop.Data;
using ClothesShop.Data.Services;
using ClothesShop.Data.Static;
using ClothesShop.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace ClothesShop.Controllers
{
    [Authorize(Roles = UserRoles.Admin)]
    public class ClothesController : Controller
    {
        private readonly IClothesService _service;

        public ClothesController(IClothesService service)
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
        public async Task<IActionResult> Filter(string searchString)
        {
            var data = await _service.GetAllAsync();
            if (!string.IsNullOrEmpty(searchString))
            {
                var filter = data.Where(x => x.Name.ToLower().Contains(searchString.ToLower()) || x.Description.ToLower().Contains(searchString.ToLower())).ToList();
                return View("Index", filter);
            }
            return View("Index", data);
        }

        [AllowAnonymous]
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
        [HttpPost]
        public async Task<IActionResult> Create(NewClothesVm clothes)
        {
            if (!ModelState.IsValid)
            {
                var dropDownData = await _service.GetNewClothesDropDowns();
                ViewBag.FashionHouse = new SelectList(dropDownData.FashionHouses, "Id", "FullName");
                ViewBag.Designers = new SelectList(dropDownData.Designers, "Id", "FullName");
                return View(clothes);
            }
            await _service.AddNewClothes(clothes);
            return RedirectToAction(nameof(Index));
        }


        public async Task<IActionResult> Edit(int id)
        {
            var clothesDetails = await _service.GetClothesByIdAsync(id);
            if(clothesDetails == null)
            {
                return View("NotFound");
            }
            var response = new NewClothesVm()
            {
                Id = clothesDetails.Id,
                Name = clothesDetails.Name,
                Description = clothesDetails.Description,
                Price = clothesDetails.Price,
                ImageUrl = clothesDetails.ImageUrl,
                ClothesCategory = clothesDetails.ClothesCategory,
                FashionHouseId = clothesDetails.FashionHouseId,
                DesignerIds = clothesDetails.Designer_Clothes.Select(x => x.DesignerId).ToList()
            };


            var dropDownData = await _service.GetNewClothesDropDowns();
            ViewBag.FashionHouse = new SelectList(dropDownData.FashionHouses, "Id", "FullName");
            ViewBag.Designers = new SelectList(dropDownData.Designers, "Id", "FullName");
            return View(response);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(int id,NewClothesVm clothes)
        {
            if(id != clothes.Id)
            {
                return View("NotFound");
            }

            if (!ModelState.IsValid)
            {
                var dropDownData = await _service.GetNewClothesDropDowns();
                ViewBag.FashionHouse = new SelectList(dropDownData.FashionHouses, "Id", "FullName");
                ViewBag.Designers = new SelectList(dropDownData.Designers, "Id", "FullName");
                return View(clothes);
            }
            await _service.UpdateClothesAsync(clothes);
            return RedirectToAction(nameof(Index));
        }


    }
}
