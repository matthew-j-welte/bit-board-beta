using System.Collections.Generic;
using System.Threading.Tasks;
using API.Models.DTOs;
using API.Interfaces;
using AutoMapper;
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
            var users = await _unitOfWork.UserRepository.GetUsersAsync();
            return Ok(users);
        }

        [HttpGet("{username}")]
        public async Task<ActionResult<IEnumerable<UserDto>>> GetUserByUsernameAsync(string username)
        {
            var user = await _unitOfWork.UserRepository.GetUserByUsernameAsync(username);
            return Ok(user);
        }
    }
}

/*
From Go Server
----------------

GET:  /users/count                      --> /users                  (This should probably be refactored to a query param on /users)
GET:  /user/{id}/persona/skills         --> /user/skills            (Do I need the user id if I'm just using the jwt to validate the current user?)
PUT:  /user/{id}/code/configuration/new --> /user/editorConfig/{unique-name}
GET:  /user/{id}/code/configurations    --> /user/editorConfigs

*/