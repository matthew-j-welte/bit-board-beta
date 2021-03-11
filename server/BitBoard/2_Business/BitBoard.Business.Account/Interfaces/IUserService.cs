using System.Collections.Generic;
using System.Threading.Tasks;
using BitBoard.Business.Views.Account.Dtos;
using BitBoard.Business.Views.Account.ViewModels;

namespace BitBoard.Business.Account.Interfaces
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