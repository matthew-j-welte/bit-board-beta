using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class UsersController : BaseApiController
    {
        [HttpGet]
        public ActionResult<IEnumerable<string>> GetUsers()
        {
            System.Console.WriteLine("Getting all users");
            return Ok((new List<string> { "Pete", "Jimmy" }));
        }

        [HttpGet("skills")]
        public ActionResult<IEnumerable<string>> GetUserSkills()
        {
            System.Console.WriteLine("Getting all skills for the user");
            return Ok((new List<string> { "C++", "SQL", ".NET" }));
        }

        [HttpGet("editorConfigs")]
        public ActionResult<IEnumerable<string>> GetEditorConfigs()
        {
            System.Console.WriteLine("Getting all editor configs");
            return Ok((new List<string> { "Dracula", "Cobalt", "Bright-n-Shiny" }));
        }

        [HttpPut("editorConfig/{name}")]
        public ActionResult UpdateEditorConfig(string name)
        {
            System.Console.WriteLine($"Creating editor config {name}");
            return NoContent();
        }
    }
}

/*
From Go Server
----------------

GET:  /users/count                      --> /users                  (This should probably be refactored to a query param on /users)
GET:  /user/{id}/persona/skills         --> /user/skills            (Do I need the user id if I'm just using the jwt to validate the current user?)
PUT:  /user/{id}/code/configuration/new --> /user/editorConfig/{unique-name}
GET:  /user/{id}/code/configurations    --> /user/editorConfigs

*/