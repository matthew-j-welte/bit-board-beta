using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class LearningResourceSuggestionsController : BaseApiController
    {
        [HttpGet]
        public ActionResult<IEnumerable<string>> GetLearningResourceSuggestions()
        {
            System.Console.WriteLine("Get all learning resource suggestions");
            return Ok((new List<string> { "Pete", "Jimmy" }));
        }

        [HttpPost]
        public ActionResult NewLearningResourceSuggestions()
        {
            System.Console.WriteLine("Creating a new learning resource suggestion");
            return NoContent();
        }        
    }
}

/*
From Go Server
----------------

POST:   /learn/resource/new                     --> /learningResourceSuggestions
PUT:    /learn/resource/{id}/{field}/increment  --> /learningResourceSuggestions/{id}


*/