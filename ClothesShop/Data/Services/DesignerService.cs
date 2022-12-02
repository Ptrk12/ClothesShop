using ClothesShop.Models;
using Microsoft.EntityFrameworkCore;

namespace ClothesShop.Data.Services
{
    public class DesignerService : IDesignerService
    {
        private readonly AppDbContext _context;

        public DesignerService(AppDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(Designer designer)
        {
            await _context.Designers.AddAsync(designer);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var result = await _context.Designers.FirstOrDefaultAsync(x=>x.Id==id);
            _context.Designers.Remove(result);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Designer>> GetAllAsync()
        {
            var result = await _context.Designers.ToListAsync();
            return result;
        }

        public async Task<Designer> GetByIdAsync(int id)
        {
            var result = await _context.Designers.FirstOrDefaultAsync(x => x.Id == id);
            return result;
        }

        public async Task<Designer> UpdateAsync(int id, Designer designer)
        {
            _context.Update(designer);
            await _context.SaveChangesAsync();
            return designer;
        }
    }
}
