using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.Linq.Expressions;

namespace ClothesShop.Data.Base
{
    public class EntityBaseRepository<T> : IEntityBaseRepository<T> where T : class, IEntityBase, new()
    {
        private readonly AppDbContext _context;

        public EntityBaseRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(T entity)
        {
            await _context.Set<T>().AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var entity = await _context.Set<T>().FirstOrDefaultAsync(x => x.Id == id);
            if (entity == null)
                return false;
            EntityEntry entityEntry = _context.Entry<T>(entity);
            entityEntry.State = EntityState.Deleted;
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<IEnumerable<T>> GetAllAsync() => await _context.Set<T>().ToListAsync();

        public async Task<IEnumerable<T>> GetAllSync(params Expression<Func<T, object>>[] includeProp)
        {
            IQueryable<T> query = _context.Set<T>();
            query = includeProp.Aggregate(query,(current,includeProp) => current.Include(includeProp));
            return await query.ToListAsync();
        }

        public async Task<T> GetByIdAsync(int id)
        {
            var entityBase = await _context.Set<T>().FirstOrDefaultAsync(x => x.Id == id);
            if (entityBase == null)
                return null;
            _context.Entry(entityBase).State = EntityState.Detached;
            return entityBase;
        }

        public async Task UpdateAsync(int id, T entity)
        {
            _context.Update<T>(entity);
            await _context.SaveChangesAsync();
        }
    }
}
