using System.Collections.Generic;
using System.Threading.Tasks;
using BitBoard.API.Shared.Controllers;
using BitBoard.Business.Learning.Interfaces;
using BitBoard.Business.Views.Learning.Dtos;
using BitBoard.Business.Views.Learning.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace BitBoard.API.Learning.Controllers
{
    public class LearningResourcesController : BaseApiController
    {
        private readonly ILearningService learningService;
        public LearningResourcesController(ILearningService learningService)
        {
            this.learningService = learningService;
        }

        [HttpGet("standard")]
        public async Task<ActionResult<IEnumerable<LearningResourceDto>>> GetAllAsync([FromQuery] string sortBy, [FromQuery] int count)
        {
            IEnumerable<LearningResourceDto> resources;
            if (sortBy != null && sortBy.Equals("viewers"))
            {
                resources = await learningService.GetTopViewedResourcesAsync(count);
            }
            else
            {
                resources = await learningService.GetAllResources();
            }
            return Ok(resources);
        }

        [HttpGet("progressions/{userId}")]
        public async Task<ActionResult<IEnumerable<UserResourceStateDto>>> GetUserResourceProgressions(string userId)
        {
            return Ok(await learningService.GetUserResourceProgressions(userId));
        }

        [HttpGet("standard/{id}")]
        public async Task<ActionResult<LearningResourceDto>> GetAsync(string id)
        {
            return Ok(await learningService.GetResourceAsync(id));
        }

        [HttpGet("detailed/{resourceId}/{userId}")]
        public async Task<ActionResult<LearningResourceModel>> GetModelAsync(string resourceId, string userId)
        {
            // TODO: Have the userId come from the decoded token
            return Ok(await learningService.GetResourceModelAsync(resourceId, userId));
        }

        [HttpPut]
        public async Task<ActionResult> UpsertAsync(LearningResourceModel learningResource)
        {
            return Ok(await learningService.UpsertResourceAsync(learningResource));
        }
    }
}
