using ClothesShop.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ClothesShop.Controllers
{
    public class FashionHouseController : Controller
    {
        private readonly AppDbContext _context;

        public FashionHouseController(AppDbContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            var data = await _context.FashionHouses.ToListAsync();
            return View(data);
        }
    }
}
