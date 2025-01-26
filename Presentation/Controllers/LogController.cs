using System.Text.Json;
using Entities.DTOs.LogDto;
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
    [Route("api/Log")]
    public class LogController : ControllerBase
    {
        private readonly IServiceManager _manager;

        public LogController(IServiceManager manager)
        {
            _manager = manager;
        }

        [HttpGet("GetAll")]
        [AuthorizePermission("Log", "Read")]
        public async Task<IActionResult> GetAllLogsAsync()
        {
            try
            {
                var users = await _manager.LogService.GetAllLogsAsync(false);
                return Ok(ApiResponse<IEnumerable<LogDto>>.Success(users, Messages.Success.Listed));
            }
            catch (Exception ex)
            {
                return BadRequest(
                    ApiResponse<IEnumerable<LogDto>>.Error(Messages.Error.ServerError)
                );
            }
        }

        [HttpGet("Get/{id:int}")]
        [AuthorizePermission("Log", "Read")]
        public async Task<IActionResult> GetOneLogByIdAsync([FromRoute] int id)
        {
            try
            {
                var user = await _manager.LogService.GetLogByIdAsync(id, false);
                return Ok(ApiResponse<LogDto>.Success(user, Messages.Success.Retrieved));
            }
            catch (System.Exception)
            {
                return BadRequest(ApiResponse<LogDto>.Error(Messages.Error.NotFound));
            }
        }

        [HttpDelete("Delete/{id:int}")]
        [AuthorizePermission("Log", "Delete")]
        public async Task<IActionResult> DeleteOneLogAsync([FromRoute] int id)
        {
            try
            {
                var user = await _manager.LogService.DeleteLogAsync(id, false);
                return Ok(ApiResponse<LogDto>.Success(user, Messages.Success.Deleted));
            }
            catch (System.Exception)
            {
                return BadRequest(ApiResponse<LogDto>.Error(Messages.Error.NotFound));
            }
        }
    }
}
