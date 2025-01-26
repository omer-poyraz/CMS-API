using System.Text.Json;
using Entities.DTOs.UserPermissionDto;
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
    [Route("api/UserPermission")]
    public class UserPermissionController : ControllerBase
    {
        private readonly IServiceManager _manager;

        public UserPermissionController(IServiceManager manager)
        {
            _manager = manager;
        }

        [HttpGet("GetAll")]
        [AuthorizePermission("UserPermission", "Read")]
        public async Task<IActionResult> GetAllUserPermissionsAsync()
        {
            try
            {
                var users = await _manager.UserPermissionService.GetAllUserPermissionsAsync(false);
                return Ok(
                    ApiResponse<IEnumerable<UserPermissionDto>>.Success(
                        users,
                        Messages.Success.Listed
                    )
                );
            }
            catch (Exception ex)
            {
                return BadRequest(
                    ApiResponse<IEnumerable<UserPermissionDto>>.Error(Messages.Error.ServerError)
                );
            }
        }

        [HttpGet("Get/{id:int}")]
        [AuthorizePermission("UserPermission", "Read")]
        public async Task<IActionResult> GetOneUserPermissionByIdAsync([FromRoute] int id)
        {
            try
            {
                var user = await _manager.UserPermissionService.GetUserPermissionByIdAsync(
                    id,
                    false
                );
                return Ok(ApiResponse<UserPermissionDto>.Success(user, Messages.Success.Retrieved));
            }
            catch (System.Exception)
            {
                return BadRequest(ApiResponse<UserPermissionDto>.Error(Messages.Error.NotFound));
            }
        }

        [HttpPost("Create")]
        [AuthorizePermission("UserPermission", "Write")]
        public async Task<IActionResult> CreateOneUserPermissionAsync(
            [FromBody] UserPermissionDtoForInsertion userPermissionDtoForInsertion
        )
        {
            try
            {
                var user = await _manager.UserPermissionService.CreateUserPermissionAsync(
                    userPermissionDtoForInsertion
                );
                return Ok(ApiResponse<UserPermissionDto>.Success(user, Messages.Success.Created));
            }
            catch (System.Exception)
            {
                return BadRequest(ApiResponse<UserPermissionDto>.Error(Messages.Error.NotFound));
            }
        }

        [HttpPut("Update")]
        [AuthorizePermission("UserPermission", "Write")]
        public async Task<IActionResult> UpdateOneUserAsync(
            [FromBody] UserPermissionDtoForUpdate userPermissionDtoForUpdate
        )
        {
            try
            {
                var user = await _manager.UserPermissionService.UpdateUserPermissionAsync(
                    userPermissionDtoForUpdate.ID,
                    userPermissionDtoForUpdate,
                    false
                );
                return Ok(ApiResponse<UserPermissionDto>.Success(user, Messages.Success.Updated));
            }
            catch (System.Exception)
            {
                return BadRequest(ApiResponse<UserPermissionDto>.Error(Messages.Error.NotFound));
            }
        }

        [HttpDelete("Delete/{id:int}")]
        [AuthorizePermission("UserPermission", "Delete")]
        public async Task<IActionResult> DeleteOneUserPermissionAsync([FromRoute] int id)
        {
            try
            {
                var user = await _manager.UserPermissionService.DeleteUserPermissionAsync(
                    id,
                    false
                );
                return Ok(ApiResponse<UserPermissionDto>.Success(user, Messages.Success.Deleted));
            }
            catch (System.Exception)
            {
                return BadRequest(ApiResponse<UserPermissionDto>.Error(Messages.Error.NotFound));
            }
        }
    }
}
