// using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class AccountController : BaseApiController
    {
        [HttpPost("login")]
        public ActionResult Login()
        {
            System.Console.WriteLine("Login Endpoint");
            return NoContent();
        }

        [HttpPost("register")]
        public ActionResult Register()
        {
            System.Console.WriteLine("Register Endpoint");
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
