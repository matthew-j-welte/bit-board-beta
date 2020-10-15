using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class ErrorReportingController : BaseApiController
    {
        [HttpGet]
        public ActionResult<IEnumerable<string>> GetErrorReports()
        {
            System.Console.WriteLine("Getting all error reports");
            return Ok((new List<string> { "Report1", "Report2" }));
        }

        [HttpPost]
        public ActionResult NewErrorReport()
        {
            System.Console.WriteLine("New error report being posted");
            return NoContent();
        }
    }
}

/*
From Go Server
----------------

GET:   /error/reports           --> /errorReports  **(Admin Only Endpoint)**
POST:  /error/reports           --> /errorReports

*/