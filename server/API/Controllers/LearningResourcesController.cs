using System.Collections.Generic;
using System.Threading.Tasks;
using API.Interfaces;
using API.Models;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class LearningResourcesController : BaseApiController
    {
        private readonly IUnitOfWork _unitOfWork;

        public LearningResourcesController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet("standard")]
        public async Task<ActionResult<IEnumerable<LearningResourceModel>>> GetLearningResourcesAsync()
        {
            var resources = await _unitOfWork.LearningResourceRepository.GetLearningResourcesAsync();
            return Ok(resources);
        }

        [HttpGet("standard/{id}")]
        public async Task<ActionResult<LearningResourceModel>> GetLearningResourceByIdAsync(int id)
        {
            var resource = await _unitOfWork.LearningResourceRepository.GetLearningResourceByIdAsync(id);
            return Ok(resource);
        }

        [HttpGet("detailed")]
        public async Task<ActionResult<IEnumerable<LearningResourceModel>>> GetLearningResourceModelsAsync()
        {
            var resources = await _unitOfWork.LearningResourceRepository.GetLearningResourceModelsAsync();
            return Ok(resources);
        }

        [HttpGet("detailed/{id}")]
        public async Task<ActionResult<LearningResourceModel>> GetLearningResourceModelByIdAsync(int id)
        {
            var resource = await _unitOfWork.LearningResourceRepository.GetLearningResourceModelByIdAsync(id);
            return Ok(resource);
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
