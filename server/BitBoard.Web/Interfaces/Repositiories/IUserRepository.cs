// using System.Collections.Generic;
// using System.Threading.Tasks;
// using API.Data.Entities;
// using API.Models;
// using API.Models.DTOs;
// using BitBoard.Web.Interfaces.Base;

// namespace API.Interfaces.Repositories
// {
//     public interface IUserRepository : IRepository<UserDto>
//     {
//         Task<IEnumerable<UserModel>> GetAllModelsAsync();
//         Task<UserModel> GetUserModelAsync(string username);
//         Task<UserDto> GetAsync(string username);
//         Task<IEnumerable<UserResourceStateDto>> GetAllResourceStatesAsync(int id);
//         Task<UserResourceStateDto> GetResourceStateAsync(int userId, int learningResourceId);
//     }
// }