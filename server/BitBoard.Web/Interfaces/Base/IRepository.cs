using System.Collections.Generic;
using System.Threading.Tasks;

namespace BitBoard.Web.Interfaces.Base
{
    public interface IRepository<T> where T : class
    {
        Task<T> AddAsync(T entity);
        Task RemoveAsync(T entity);
        Task<T> GetAsync(int id);
        Task UpdateAsync(T entity);
        Task<IEnumerable<T>> GetAllAsync();
    }
}