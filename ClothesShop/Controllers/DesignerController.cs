using ClothesShop.Data;
using ClothesShop.Data.Services;
using ClothesShop.Models;
using Microsoft.AspNetCore.Mvc;

namespace ClothesShop.Controllers
{
    public class DesignerController : Controller
    {
        private readonly IDesignerService _service;

        public DesignerController(IDesignerService service)
        {
            _service = service;
        }

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
            var errors = ModelState.Values.SelectMany(v => v.Errors);
            return View();
            
        }
        public async Task<IActionResult> Details(int id)
        {
            var designer = await _service.GetByIdAsync(id);
            if(designer == null)
            {
                return View("Empty");
            }
            return View(designer);
        }
    }
}
