using System.Threading.Tasks;
using API.Models;
using API.Models.DTOs;
using BitBoard.Web.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class UsersController : BaseApiController
    {
        IUserService userService;

        public UsersController(IUserService userService)
        {
            this.userService = userService;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<UserDto>> GetAsync(string id)
        {
            return Ok(await userService.GetUserAsync(id));
        }

        [HttpGet("GetModel/{id}")]
        public async Task<ActionResult<UserDto>> GetModelAsync(string id)
        {
            return Ok(await userService.GetUserModelAsync(id));
        }

        [HttpGet("GetByUsername/{username}")]
        public async Task<ActionResult<UserDto>> GetByUsernameAsync(string username)
        {
            return Ok(await userService.GetUserByUsernameAsync(username));
        }
    }
}
