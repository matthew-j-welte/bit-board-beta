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
        public async Task<ActionResult<IEnumerable<UserResourceStateDto>>> GetResourceProgressionsByUserIdAsync(int id)
        {
            var userProgressions = await _unitOfWork.UserRepository.GetLearningResourceProgressionsAsync(id);
            return Ok(userProgressions);
        }

        [HttpGet("{userId}/resourceProgress/{learningResourceId}")]
        public async Task<ActionResult<IEnumerable<UserResourceStateDto>>> GetResourceProgressionAsync(int userId, int learningResourceId)
        {
            var userProgressions = await _unitOfWork.UserRepository.GetLearningResourceProgressionAsync(userId, learningResourceId);
            return Ok(userProgressions);
        }
    }
}
