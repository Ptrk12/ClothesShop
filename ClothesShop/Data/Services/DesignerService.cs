using ClothesShop.Data.Base;
using ClothesShop.Models;
using Microsoft.EntityFrameworkCore;

namespace ClothesShop.Data.Services
{
    public class DesignerService :EntityBaseRepository<Designer>, IDesignerService
    {
        private readonly AppDbContext _context;

        public DesignerService(AppDbContext context) : base(context) { }

      
    }
}
