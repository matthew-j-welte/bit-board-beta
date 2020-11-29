using System.Collections.Generic;
using System.Threading.Tasks;
using API.Models.DTOs;
using API.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class UsersController : BaseApiController
    {
        private readonly IUnitOfWork _unitOfWork;

        public UsersController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserDto>>> GetUsersAsync()
        {
            var users = await _unitOfWork.UserRepository.GetUserModelsAsync();
            return Ok(users);
        }

        [HttpGet("{username}")]
        public async Task<ActionResult<IEnumerable<UserDto>>> GetUserByUsernameAsync(string username)
        {
            var user = await _unitOfWork.UserRepository.GetUserModelByUsernameAsync(username);
            return Ok(user);
        }

        [HttpGet("{id}/resourceProgress")]
        public async Task<ActionResult<IEnumerable<UserResourceProgressDto>>> GetResourceProgressionsByUsernameAsync(int id)
        {
            var userProgressions = await _unitOfWork.UserRepository.GetLearningResourceProgressionsAsync(id);
            return Ok(userProgressions);
        }
    }
}
