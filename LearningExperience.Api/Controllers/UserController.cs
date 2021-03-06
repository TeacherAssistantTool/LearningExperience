﻿using LearningExperience.Models;
using LearningExperience.Models.DTO;
using LearningExperience.Models.Enums;
using LearningExperience.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LearningExperience.Controllers
{

    [ApiController]
    [Route("api/v1/[controller]")]
    [Authorize]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost("RegisterUser")]
        public async Task<IActionResult> RegisterUser([FromBody] AuthenticateUserDTO userDTO)
        {
            await _userService.AddUser(userDTO);
            return Ok(new { StatusCode = ReturnStatusCode.Ok });
        }

        [HttpGet("GetAll")]
        public IEnumerable<User> GetAll()
        {
            var advisors = _userService.GetAll();
            return advisors;
        }

        [HttpPost("RemoveUser")]
        public async Task<IActionResult> RemoveUser([FromBody] string userId)
        {
            await _userService.RemoveUser(userId);
            return Ok(new { StatusCode = ReturnStatusCode.Ok });
        }

        [HttpPost("UpdateUser")]
        public async Task<IActionResult> UpdateUser(UserDTO userDTO)
        {
            await _userService.UpdateUser(userDTO);
            return Ok(new { StatusCode = ReturnStatusCode.Ok });
        }

        [HttpGet("GetProgressByModule")]
        public double GetProgressByModule(string userId, GameLevelType module)
        {
            UserProgressDTO userProgress = new UserProgressDTO()
            {
                UserId = userId,
                Module = module
            };

            return _userService.GetProgressByModule(userProgress);
        }

        [HttpPost("UpdateUserProgress")]
        public async Task<IActionResult> UpdateUserProgress(UserProgressUpdateDTO userProgress)
        {
            await  _userService.UpdateUserProgress(userProgress);
            return Ok(new { StatusCode = ReturnStatusCode.Ok });
        }

        [HttpGet("GetProgressByUser")]
        public IList<UserProgressResultDTO> GetProgressByUser(string userId)
        {
            return _userService.GetProgressByUser(userId);
        }

        [HttpGet("GetUserById")]
        public UserReturnDTO GetUserById(string id)
        {
            return _userService.GetUserById(id);
        }
    }
}
