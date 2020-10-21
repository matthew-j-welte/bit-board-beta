// using System.Threading.Tasks;
using API.Models.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class AccountController : BaseApiController
    {
        [HttpPost("login")]
        public ActionResult Login(LoginDto loginDto)
        {
            System.Console.WriteLine($"Logging in {loginDto.Username}");
            return NoContent();
        }

        [HttpPost("register")]
        public ActionResult Register(RegisterDto registerDto)
        {
            System.Console.WriteLine($"Registering in {registerDto.UserName}");
            return NoContent();
        }
    }
}



/*
From Go Server
----------------

POST: /user/login  -->  /account/login
POST: /user/new    -->  /account/register

*/
