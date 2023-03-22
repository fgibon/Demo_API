using System.Linq.Expressions;

namespace arfan.Repository.IRepository
{
    public interface IRepository<T> where T : class
    {
        //Para obtener todos los datos
        Task<List<T>> GetAllAsync(Expression<Func<T, bool>>? filter = null);
        //Para obtener solo uno
        Task<T> GetAsync(Expression<Func<T, bool>> filter = null, bool tracked = true);
        Task CreateAsync(T entity);
        Task UpdateAsync(T entity);
        Task RemoveAsync(T entity);
        Task SaveAsync();
    }
}
