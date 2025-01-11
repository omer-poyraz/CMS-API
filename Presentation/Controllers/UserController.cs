using System.Text.Json;
using Entities.DTOs.UserDto;
using Entities.RequestFeature.User;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Services.Contracts;
using Services.ResultModels.Requests;

namespace Presentation.Controllers
{
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
        [AuthorizePermission("User", "Read")]
        public async Task<IActionResult> GetAllUsersAsync([FromQuery] UserParameters userParameters)
        {
            var users = await _manager.UserService.GetAllUsersAsync(userParameters, false);
            Response.Headers.Add("X-Pagination", JsonSerializer.Serialize(users.metaData));
            return Ok(new GetAllRequest<IEnumerable<UserDto>>(users.userDtos, 1, "User", _logger));
        }

        [HttpGet("Get/{userId}")]
        [AuthorizePermission("User", "Read")]
        public async Task<IActionResult> GetOneUserByIdAsync([FromRoute] string? userId)
        {
            var user = await _manager.UserService.GetOneUserByIdAsync(userId, false);
            return Ok(new GetRequest<UserDto>(user, 2, "User", _logger));
        }

        [HttpPut("Update")]
        [AuthorizePermission("User", "Write")]
        public async Task<IActionResult> UpdateOneUserAsync(
            [FromBody] UserDtoForUpdate userDtoForUpdate
        )
        {
            var user = await _manager.UserService.UpdateOneUserAsync(
                userDtoForUpdate.UserId,
                userDtoForUpdate,
                false
            );
            return Ok(new UpdateRequest<UserDto>(user, 4, "User", _logger));
        }

        [HttpDelete("Delete/{userId}")]
        [AuthorizePermission("User", "Delete")]
        public async Task<IActionResult> DeleteOneUserAsync([FromRoute] string? userId)
        {
            var user = await _manager.UserService.DeleteOneUserAsync(userId, false);
            return Ok(new DeleteRequest<UserDto>(user, 5, "User", _logger));
        }

        [HttpPut("ChangePassword/{userId}")]
        [AuthorizePermission("User", "Write")]
        public async Task<IActionResult> ChangePaswordAsync(
            [FromRoute] string? userId,
            [FromBody] UserDtoForChangePassword changePassword
        )
        {
            var user = await _manager.UserService.ChangePasswordAsync(
                userId,
                changePassword.CurrentPassword!,
                changePassword.NewPassword!,
                false
            );
            return Ok(new UpdateRequest<UserDto>(user, 4, "User", _logger));
        }
    }
}
