using ClothesShop.Data;
using Microsoft.AspNetCore.Mvc;

namespace ClothesShop.Controllers
{
    public class DesignerController : Controller
    {
        private readonly AppDbContext _context;

        public DesignerController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var data = _context.Designers.ToList();
            return View(data);
        }
    }
}
