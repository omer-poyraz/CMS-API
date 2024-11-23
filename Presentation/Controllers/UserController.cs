﻿using Entities.DTOs.UserDto;
using Entities.RequestFeature.User;
using Services.ResultModels.Requests;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Services.Contracts;
using System.Text.Json;

namespace Presentation.Controllers
{
    //[Authorize(AuthenticationSchemes = "Bearer")]
    [ApiController]
    [Route("api/User")]
    public class UserController : ControllerBase
    {
        private readonly IServiceManager _manager;
        private readonly ILogService _logger;
        public UserController(IServiceManager manager, ILogService logger)
        {
            _manager = manager;
            _logger = logger;
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAllUsersAsync([FromQuery] UserParameters userParameters)
        {
            var users = await _manager.UserService.GetAllUsersAsync(userParameters, false);
            Response.Headers.Add("X-Pagination", JsonSerializer.Serialize(users.metaData));
            return Ok(new GetAllRequest<IEnumerable<UserDto>>(users.userDtos, 1, "User", _logger));
        }

        [HttpGet("Get/{userId}")]
        public async Task<IActionResult> GetOneUserByIdAsync([FromRoute] string? userId)
        {
            var user = await _manager.UserService.GetOneUserByIdAsync(userId, false);
            return Ok(new GetRequest<UserDto>(user, 2, "User", _logger));
        }

        [HttpPut("Update/{userId}")]
        public async Task<IActionResult> UpdateOneUserAsync([FromRoute] string? userId, [FromBody] UserDtoForUpdate userDtoForUpdate)
        {
            var user = await _manager.UserService.UpdateOneUserAsync(userId, userDtoForUpdate, false);
            return Ok(new UpdateRequest<UserDto>(user, 4, "User", _logger));
        }

        [HttpDelete("Delete/{userId}")]
        public async Task<IActionResult> DeleteOneUserAsync([FromRoute] string? userId)
        {
            var user = await _manager.UserService.DeleteOneUserAsync(userId, false);
            return Ok(new DeleteRequest<UserDto>(user, 5, "User", _logger));
        }

        [HttpPut("ChangePassword/{userId}")]
        public async Task<IActionResult> ChangePaswordAsync([FromRoute] string? userId, [FromBody] UserDtoForChangePassword changePassword)
        {
            var user = await _manager.UserService.ChangePasswordAsync(userId, changePassword.CurrentPassword!, changePassword.NewPassword!, false);
            return Ok(new UpdateRequest<UserDto>(user, 4, "User", _logger));
        }
    }
}
