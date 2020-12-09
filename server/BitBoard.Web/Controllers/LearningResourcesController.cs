using System.Collections.Generic;
using System.Threading.Tasks;
using API.Interfaces;
using API.Models;
using API.Models.DTOs;
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
        public async Task<ActionResult<IEnumerable<LearningResourceDto>>> GetLearningResourcesAsync([FromQuery] string sortBy, [FromQuery] int count)
        {
            IEnumerable<LearningResourceDto> resources;
            if (sortBy.Equals("viewers")) {
                resources = await _unitOfWork.LearningResourceRepository.GetTopViewedLearningResourcesAsync(count);
            }
            else {
                resources = await _unitOfWork.LearningResourceRepository.GetLearningResourcesAsync();
            }
            return Ok(resources);
        }

        [HttpGet("standard/{id}")]
        public async Task<ActionResult<LearningResourceDto>> GetLearningResourceByIdAsync(int id)
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

        [HttpGet("detailed/{resourceId}/{userId}")]
        public async Task<ActionResult<LearningResourceModel>> GetLearningResourceModelByIdAsync(int resourceId, int userId)
        {
            // TODO: Have the userId come from the decoded token
            var resource = await _unitOfWork.LearningResourceRepository.GetLearningResourceModelByIdAsync(resourceId, userId);
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

        [HttpPut("user/{userId}/post")]
        public async Task<ActionResult> UpdateResourcePost(int userId, PostDto post)
        {
            var updatedPost = await _unitOfWork.LearningResourceRepository.UpdateResourcePost(post, userId);
            return Ok(updatedPost);
        }

        [HttpPost("posts")]
        public async Task<ActionResult> NewResourcePost(PostDto post)
        {
            var addedPost = await _unitOfWork.LearningResourceRepository.NewResourcePost(post);
            return Ok(addedPost);
        }
    }
}
