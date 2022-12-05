using System.Linq.Expressions;

namespace ClothesShop.Data.Base
{
    public interface IEntityBaseRepository<T> where T : class,IEntityBase, new()
    {
        Task<IEnumerable<T>> GetAllAsync();
        Task<IEnumerable<T>> GetAllSync(params Expression<Func<T, object>>[] includeProp);
        Task<T> GetByIdAsync(int id);
        Task AddAsync(T entity);
        Task UpdateAsync(int id, T entity);
        Task DeleteAsync(int id);
    }
}
