using System.Collections.Generic;
using System.Threading.Tasks;
using API.Models.DTOs;
using API.Interfaces;
using API.Interfaces.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class SkillsController : BaseApiController
    {
        private readonly IUnitOfWork _unitOfWork;

        public SkillsController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<SkillDto>>> GetAllAsync()
        {
            var skills = await _unitOfWork.SkillsRepository.GetAllAsync();
            return Ok(skills);
        }
    }
}
