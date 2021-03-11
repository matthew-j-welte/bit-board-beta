using System.Collections.Generic;
using System.Threading.Tasks;
using BitBoard.API.Shared.Controllers;
using BitBoard.Business.Learning.Interfaces;
using BitBoard.Business.Views.Learning.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace BitBoard.API.Learning.Controllers
{
    public class SkillsController : BaseApiController
    {
        private readonly ILearningService learningService;

        public SkillsController(ILearningService learningService)
        {
            this.learningService = learningService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<SkillDto>>> GetAllAsync()
        {
            return Ok(await learningService.GetAllSkills());
        }
    }
}
