using System.Collections.Generic;
using System.Threading.Tasks;
using API.Data.Entities;

namespace BitBoard.Web.Interfaces.Base
{
    public interface IBaseRepository<T> where T : BaseEntity
    {
        Task<T> UpsertAsync(T entity);
        Task RemoveAsync(T entity);
        Task<T> GetAsync(string id);
        Task<IEnumerable<T>> GetMultipleAsync(IEnumerable<string> ids);
        Task<IEnumerable<T>> GetAllAsync();
        Task Clear();
    }
}