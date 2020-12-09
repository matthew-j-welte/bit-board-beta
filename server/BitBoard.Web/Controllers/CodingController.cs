using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class CodingController : BaseApiController
    {
        [HttpPost("submission")]
        public ActionResult SubmitCodeSolution()
        {
            System.Console.WriteLine("Submitting solution to coding problem");
            return NoContent();
        }
    }
}

/*
From Go Server
----------------

POST: /user/{id}/code/submit/{language} --> /coding/submission

*/