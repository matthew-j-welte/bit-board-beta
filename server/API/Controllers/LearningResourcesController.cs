using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class LearningResourcesController : BaseApiController
    {
        [HttpGet]
        public ActionResult<IEnumerable<string>> GetLearningResources()
        {
            System.Console.WriteLine("Getting all learning resources");
            return Ok((new List<string> { "GraphQL Video", "MongoDB Video" }));
        }

        [HttpPost]
        public ActionResult NewLearningResource()
        {
            System.Console.WriteLine("New learning resource being posted");
            return NoContent();
        }

        [HttpPut("{learningResourceId}")]
        public ActionResult UpdateLearningResource(string learningResourceId)
        {
            System.Console.WriteLine($"Updating learning resource: {learningResourceId}");
            return NoContent();
        }
    }
}

/*
From Go Server
----------------

GET:  /learn/resources                      --> /learningResources
POST: --------------------                  --> /learningResources/{learningResourceId}
PUT:  --------------------                  --> /learningResources/{learningResourceId}

*/