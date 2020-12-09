using System.Collections.Generic;
using System.Threading.Tasks;

namespace BitBoard.Web.Interfaces.Base
{
    public interface IRepository<T> where T : class
    {
        Task<T> AddAsync(T entity);
        void Remove(T entity);
        Task<T> GetAsync(int id);
        T Update(T entity);
        Task<IEnumerable<T>> GetAllAsync();
    }
}