// using System.Threading.Tasks;
using System.Threading.Tasks;
using API.Interfaces;
using API.Models.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class AccountController : BaseApiController
    {
        private readonly IUnitOfWork _unitOfWork;

        public AccountController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpPost("login")]
        public async Task<ActionResult> LoginAsync(LoginDto loginDto)
        {
            var user = await _unitOfWork.UserRepository.GetUserByUsernameAsync(loginDto.Username);
            if (user.Password == loginDto.Password)
            {
                return Ok(user);
            }
            return BadRequest();
        }

        [HttpPost("register")]
        public ActionResult Register(UserDto user)
        {
            System.Console.WriteLine($"Registering in {user.UserName}");
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
