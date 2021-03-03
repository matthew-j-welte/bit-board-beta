// using System.Threading.Tasks;
using System.Threading.Tasks;
using API.Models.DTOs;
using Microsoft.AspNetCore.Mvc;
using BitBoard.Web.Interfaces.Services;
using API.Models;

namespace API.Controllers
{
    public class AccountController : BaseApiController
    {
        private readonly IUserService userService;
        public AccountController(IUserService userService)
        {
            this.userService = userService;
        }

        [HttpPost("login")]
        public async Task<ActionResult> LoginAsync(LoginDto loginDto)
        {
            var user = await userService.GetUserByUsernameAsync(loginDto.Username);
            if (user.Password == loginDto.Password)
            {
                return Ok(user);
            }
            return BadRequest();
        }

        [HttpPost("register")]
        public async Task<ActionResult> Register(UserModel userRegistration)
        {
            System.Console.WriteLine(userRegistration.ToString());
            var user = await userService.UpsertUserAsync(userRegistration);
            return Ok(user);
        }
    }
}
