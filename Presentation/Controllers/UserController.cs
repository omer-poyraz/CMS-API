using System.Text.Json;
using Entities.DTOs.UserDto;
using Entities.RequestFeature.User;
using Entities.Response;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Services.Contracts;
using Services.Extensions;
using Services.ResultModels.Requests;

namespace Presentation.Controllers
{
    [ApiController]
    [Route("api/User")]
    public class UserController : ControllerBase
    {
        private readonly IServiceManager _manager;

        public UserController(IServiceManager manager)
        {
            _manager = manager;
        }

        [HttpGet("GetAll")]
        [AuthorizePermission("User", "Read")]
        public async Task<IActionResult> GetAllUsersAsync([FromQuery] UserParameters userParameters)
        {
            try
            {
                var users = await _manager.UserService.GetAllUsersAsync(userParameters, false);
                Response.Headers.Add("X-Pagination", JsonSerializer.Serialize(users.metaData));
                return Ok(
                    ApiResponse<IEnumerable<UserDto>>.Success(
                        users.userDtos,
                        Messages.Success.Listed
                    )
                );
            }
            catch (Exception ex)
            {
                return BadRequest(
                    ApiResponse<IEnumerable<UserDto>>.Error(Messages.Error.ServerError)
                );
            }
        }

        [HttpGet("Get/{userId}")]
        [AuthorizePermission("User", "Read")]
        public async Task<IActionResult> GetOneUserByIdAsync([FromRoute] string? userId)
        {
            var user = await _manager.UserService.GetOneUserByIdAsync(userId, false);
            return Ok(ApiResponse<UserDto>.Success(user, Messages.Success.Retrieved));
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
            return Ok(ApiResponse<UserDto>.Success(user, Messages.Success.Updated));
        }

        [HttpDelete("Delete/{userId}")]
        [AuthorizePermission("User", "Delete")]
        public async Task<IActionResult> DeleteOneUserAsync([FromRoute] string? userId)
        {
            var user = await _manager.UserService.DeleteOneUserAsync(userId, false);
            return Ok(ApiResponse<UserDto>.Success(user, Messages.Success.Deleted));
        }

        [HttpPut("ChangePassword/{userId}")]
        [AuthorizePermission("User", "Write")]
        public async Task<IActionResult> ChangePaswordAsync(
            [FromRoute] string? userId,
            [FromBody] UserDtoForChangePassword changePassword
        )
        {
            try
            {
                var user = await _manager.UserService.ChangePasswordAsync(
                    userId,
                    changePassword.CurrentPassword!,
                    changePassword.NewPassword!,
                    false
                );
                return Ok(ApiResponse<UserDto>.Success(user, Messages.Success.PasswordChanged));
            }
            catch (System.Exception)
            {
                return BadRequest(ApiResponse<UserDto>.Error(Messages.Error.PasswordChangeFailed));
            }
        }
    }
}
