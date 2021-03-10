using System.Collections.Generic;
using System.Threading.Tasks;
using API.Models.DTOs;
using Microsoft.AspNetCore.Mvc;
using BitBoard.Web.Interfaces.Services;

namespace API.Controllers
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
