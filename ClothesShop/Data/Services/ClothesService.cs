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

        public async Task AddNewClothes(NewClothesVm data)
        {
            var newClothes = new Clothes()
            {

                Name = data.Name,
                Description = data.Description,
                Price = data.Price,
                ImageUrl = data.ImageUrl,
                ClothesCategory = data.ClothesCategory,
                FashionHouseId = data.FashionHouseId,
            };
            await _context.Clothes.AddAsync(newClothes);
            await _context.SaveChangesAsync();

            foreach (var designerId in data.DesignerIds)
            {
                var newDesignerClothes = new Designer_Clothes()
                {
                    ClothesId = newClothes.Id,
                    DesignerId = designerId
                };
                await _context.Designers_Clothes.AddAsync(newDesignerClothes);
            }
            await _context.SaveChangesAsync();

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

        public async Task UpdateClothesAsync(NewClothesVm data)
        {
            var dbclothes = await _context.Clothes.FirstOrDefaultAsync(x => x.Id == data.Id);
            if(dbclothes != null)
            {

                dbclothes.Name = data.Name;
                dbclothes.Description = data.Description;
                dbclothes.Price = data.Price;
                dbclothes.ImageUrl = data.ImageUrl;
                dbclothes.ClothesCategory = data.ClothesCategory;
                dbclothes.FashionHouseId = data.FashionHouseId;
                await _context.SaveChangesAsync();
            }

            var existingDesigners = _context.Designers_Clothes.Where(x => x.ClothesId == data.Id).ToList();
            _context.Designers_Clothes.RemoveRange(existingDesigners);
            await _context.SaveChangesAsync();


            foreach (var designerId in data.DesignerIds)
            {
                var newDesignerClothes = new Designer_Clothes()
                {
                    ClothesId = data.Id,
                    DesignerId = designerId
                };
                await _context.Designers_Clothes.AddAsync(newDesignerClothes);
            }
            await _context.SaveChangesAsync();
        }
    }
}
