using System.Collections.Generic;
using System.Threading.Tasks;
using API.Data.Entities;
using API.Models;
using API.Models.DTOs;

namespace API.Interfaces
{
    public interface IUserRepository
    {
        Task<IEnumerable<UserModel>> GetUserModelsAsync();
        Task<UserModel> GetUserModelByUsernameAsync(string username);
        Task<IEnumerable<UserDto>> GetUsersAsync();
        Task<UserDto> GetUserByUsernameAsync(string username);
        Task<IEnumerable<CodeEditorConfigurationDto>> GetCodeEditorConfigurationsAsync();
        void InsertUserAsync(User user);
        void DeletetUser(User user);
        void UpdateUser(User user);
    }
}