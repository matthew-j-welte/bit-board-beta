using System.Threading.Tasks;
using BitBoard.API.Shared.Controllers;
using BitBoard.Business.Account.Interfaces;
using BitBoard.Business.Views.Account.Dtos;
using BitBoard.Business.Views.Account.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace BitBoard.API.Account
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
