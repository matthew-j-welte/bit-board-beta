using System.Collections.Generic;
using System.Threading.Tasks;
using API.Models;
using API.Models.DTOs;

namespace BitBoard.Web.Interfaces.Services
{
    public interface IUserService
    {
        Task<UserDto> GetUserAsync(string id);
        Task<UserDto> GetUserByUsernameAsync(string username);
        Task<IEnumerable<UserDto>> GetAllUsers();
        Task<UserModel> GetUserModelAsync(string userId);
        Task<UserModel> UpsertUserAsync(UserModel user);
    }
}