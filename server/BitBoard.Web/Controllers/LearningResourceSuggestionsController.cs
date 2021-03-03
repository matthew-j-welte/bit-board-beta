using API.Models.DTOs;
using BitBoard.Web.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class LearningResourceSuggestionsController : BaseApiController
    {
        private readonly ILearningService learningService;

        public LearningResourceSuggestionsController(ILearningService learningService)
        {
            this.learningService = learningService;
        }

        [HttpPost]
        public ActionResult NewLearningResourceSuggestion(LearningResourceSuggestionDto resourceSuggestion)
        {
            return Ok(learningService.UpsertResourceSuggestionAsync(resourceSuggestion));
        }
    }
}
