using System.Collections.Generic;
using API.Interfaces;
using API.Interfaces.Repositories;
using API.Models.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class LearningResourceSuggestionsController : BaseApiController
    {
        private readonly IUnitOfWork _unitOfWork;

        public LearningResourceSuggestionsController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpPost]
        public ActionResult NewLearningResourceSuggestion(LearningResourceSuggestionDto resourceSuggestion)
        {
            _unitOfWork.LearningResourceSuggestionRepository.AddAsync(resourceSuggestion);
            return Ok();
        }
    }
}

/*
From Go Server
----------------

POST:   /learn/resource/new                     --> /learningResourceSuggestions
PUT:    /learn/resource/{id}/{field}/increment  --> /learningResourceSuggestions/{id}


*/