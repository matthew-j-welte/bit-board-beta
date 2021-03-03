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
        Task<List<T>> GetAllAsync();
        Task Clear();
    }
}