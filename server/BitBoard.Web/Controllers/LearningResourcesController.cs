using System.Collections.Generic;
using System.Threading.Tasks;
using API.Interfaces;
using API.Interfaces.Repositories;
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
        public async Task<ActionResult<IEnumerable<LearningResourceDto>>> GetAllAsync([FromQuery] string sortBy, [FromQuery] int count)
        {
            IEnumerable<LearningResourceDto> resources;
            if (sortBy.Equals("viewers")) {
                resources = await _unitOfWork.LearningResourceRepository.GetTopViewedAsync(count);
            }
            else {
                resources = await _unitOfWork.LearningResourceRepository.GetAllAsync();
            }
            return Ok(resources);
        }

        [HttpGet("standard/{id}")]
        public async Task<ActionResult<LearningResourceDto>> GetAsync(int id)
        {
            var resource = await _unitOfWork.LearningResourceRepository.GetAsync(id);
            return Ok(resource);
        }

        [HttpGet("detailed")]
        public async Task<ActionResult<IEnumerable<LearningResourceModel>>> GetAllModelsAsync()
        {
            var resources = await _unitOfWork.LearningResourceRepository.GetAllModelsAsync();
            return Ok(resources);
        }

        [HttpGet("detailed/{resourceId}/{userId}")]
        public async Task<ActionResult<LearningResourceModel>> GetModelAsync(int resourceId, int userId)
        {
            // TODO: Have the userId come from the decoded token
            var resource = await _unitOfWork.LearningResourceRepository.GetModelAsync(resourceId, userId);
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
        public async Task<ActionResult> UpdatePostAsync(int userId, PostDto post)
        {
            var updatedPost = await _unitOfWork.LearningResourceRepository.UpdatePostAsync(post, userId);
            return Ok(updatedPost);
        }

        [HttpPost("posts")]
        public async Task<ActionResult> AddPostAsync(PostDto post)
        {
            var addedPost = await _unitOfWork.LearningResourceRepository.AddPostAsync(post);
            return Ok(addedPost);
        }
    }
}
