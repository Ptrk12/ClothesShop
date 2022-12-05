using ClothesShop.Data.Base;
using ClothesShop.Models;

namespace ClothesShop.Data.Services
{
    public interface IClothesService:IEntityBaseRepository<Clothes>
    {
        Task<Clothes> GetClothesByIdAsync(int id);
    }
}
