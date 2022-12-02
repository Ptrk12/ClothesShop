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

        public void Delete(int id)
        {
            throw new NotImplementedException();
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

        public Designer Update(int id, Designer designer)
        {
            throw new NotImplementedException();
        }
    }
}
