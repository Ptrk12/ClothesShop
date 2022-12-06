using ClothesShop.Data.Base;
using ClothesShop.Data.ViewModels;
using ClothesShop.Models;
using Microsoft.EntityFrameworkCore;

namespace ClothesShop.Data.Services
{
    public class ClothesService:EntityBaseRepository<Clothes>, IClothesService
    {
        private readonly AppDbContext _context;
        public ClothesService(AppDbContext context):base(context) 
        { 
            _context = context;
        }

        public async Task<Clothes> GetClothesByIdAsync(int id)
        {
            var item = _context.Clothes
                .Include(f => f.FashionHouse)
                .Include(dc => dc.Designer_Clothes)
                .ThenInclude(d => d.Designer)
                .FirstOrDefaultAsync(x => x.Id== id);
            return await item;
        }

        public async Task<NewClothesDropDownsVm> GetNewClothesDropDowns()
        {
            var result = new NewClothesDropDownsVm()
            {
                Designers = await _context.Designers.OrderBy(x => x.FullName).ToListAsync(),
                FashionHouses = await _context.FashionHouses.OrderBy(x => x.FullName).ToListAsync()
            };

            return result;
        }
    }
}
