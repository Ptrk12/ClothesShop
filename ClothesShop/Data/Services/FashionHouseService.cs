using ClothesShop.Data.Base;
using ClothesShop.Models;

namespace ClothesShop.Data.Services
{
    public class FashionHouseService:EntityBaseRepository<FashionHouse>, IFashionHouseService
    {
        public FashionHouseService(AppDbContext context) :base(context) { }
    }
}
