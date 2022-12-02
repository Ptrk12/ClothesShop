using ClothesShop.Models;

namespace ClothesShop.Data.Services
{
    public interface IDesignerService
    {
        Task<IEnumerable<Designer>> GetAllAsync();
        Task<Designer> GetByIdAsync(int id);
        Task AddAsync(Designer designer);
        Task<Designer> UpdateAsync(int id, Designer designer);
        Task DeleteAsync(int id);
    }
}
