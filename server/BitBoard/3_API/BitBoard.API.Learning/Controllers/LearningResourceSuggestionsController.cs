using BitBoard.API.Shared.Controllers;
using BitBoard.Business.Learning.Interfaces;
using BitBoard.Business.Views.Learning.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace BitBoard.API.Learning.Controllers
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
