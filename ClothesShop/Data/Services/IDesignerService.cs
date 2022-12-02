using ClothesShop.Models;

namespace ClothesShop.Data.Services
{
    public interface IDesignerService
    {
        Task<IEnumerable<Designer>> GetAllAsync();
        Task<Designer> GetByIdAsync(int id);
        Task AddAsync(Designer designer);
        Designer Update(int id, Designer designer);
        void Delete(int id);
    }
}
