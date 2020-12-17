using System.Collections.Generic;
using System.Threading.Tasks;
using API.Models.DTOs;
using API.Interfaces;
using API.Interfaces.Repositories;
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
        public async Task<ActionResult<IEnumerable<UserDto>>> GetAllAsync()
        {
            var users = await _unitOfWork.UserRepository.GetAllModelsAsync();
            return Ok(users);
        }

        [HttpGet("{username}")]
        public async Task<ActionResult<IEnumerable<UserDto>>> GetAsync(string username)
        {
            var user = await _unitOfWork.UserRepository.GetUserModelAsync(username);
            return Ok(user);
        }

        [HttpGet("{id}/resourceProgress")]
        public async Task<ActionResult<IEnumerable<UserResourceStateDto>>> GetResourceProgressionsByUserIdAsync(int id)
        {
            var userProgressions = await _unitOfWork.UserRepository.GetAllResourceStatesAsync(id);
            return Ok(userProgressions);
        }

        [HttpGet("{userId}/resourceProgress/{learningResourceId}")]
        public async Task<ActionResult<IEnumerable<UserResourceStateDto>>> GetResourceProgressionAsync(int userId, int learningResourceId)
        {
            var userProgressions = await _unitOfWork.UserRepository.GetResourceStateAsync(userId, learningResourceId);
            return Ok(userProgressions);
        }
    }
}
