using System.Text.Json;
using Entities.DTOs.ServicesDto;
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
    [Route("api/Services")]
    public class ServicesController : ControllerBase
    {
        private readonly IServiceManager _manager;

        public ServicesController(IServiceManager manager)
        {
            _manager = manager;
        }

        [HttpGet("GetAll")]
        [AuthorizePermission("Services", "Read")]
        public async Task<IActionResult> GetAllServicessAsync()
        {
            try
            {
                var users = await _manager.ServicesService.GetAllServicesAsync(false);
                return Ok(
                    ApiResponse<IEnumerable<ServicesDto>>.Success(users, Messages.Success.Listed)
                );
            }
            catch (Exception ex)
            {
                return BadRequest(
                    ApiResponse<IEnumerable<ServicesDto>>.Error(Messages.Error.ServerError)
                );
            }
        }

        [HttpGet("Get/{id:int}")]
        [AuthorizePermission("Services", "Read")]
        public async Task<IActionResult> GetOneServicesByIdAsync([FromRoute] int id)
        {
            try
            {
                var user = await _manager.ServicesService.GetServicesByIdAsync(id, false);
                return Ok(ApiResponse<ServicesDto>.Success(user, Messages.Success.Retrieved));
            }
            catch (System.Exception)
            {
                return BadRequest(ApiResponse<ServicesDto>.Error(Messages.Error.NotFound));
            }
        }

        [HttpPost("Create")]
        [AuthorizePermission("Services", "Write")]
        public async Task<IActionResult> CreateOneServicesAsync(
            [FromBody] ServicesDtoForInsertion servicesDtoForInsertion
        )
        {
            try
            {
                var user = await _manager.ServicesService.CreateServicesAsync(
                    servicesDtoForInsertion
                );
                return Ok(ApiResponse<ServicesDto>.Success(user, Messages.Success.Created));
            }
            catch (System.Exception)
            {
                return BadRequest(ApiResponse<ServicesDto>.Error(Messages.Error.NotFound));
            }
        }

        [HttpPut("Update")]
        [AuthorizePermission("Services", "Write")]
        public async Task<IActionResult> UpdateOneUserAsync(
            [FromBody] ServicesDtoForUpdate servicesDtoForUpdate
        )
        {
            try
            {
                var user = await _manager.ServicesService.UpdateServicesAsync(
                    servicesDtoForUpdate.ID,
                    servicesDtoForUpdate,
                    false
                );
                return Ok(ApiResponse<ServicesDto>.Success(user, Messages.Success.Updated));
            }
            catch (System.Exception)
            {
                return BadRequest(ApiResponse<ServicesDto>.Error(Messages.Error.NotFound));
            }
        }

        [HttpDelete("Delete/{id:int}")]
        [AuthorizePermission("Services", "Delete")]
        public async Task<IActionResult> DeleteOneServicesAsync([FromRoute] int id)
        {
            try
            {
                var user = await _manager.ServicesService.DeleteServicesAsync(id, false);
                return Ok(ApiResponse<ServicesDto>.Success(user, Messages.Success.Deleted));
            }
            catch (System.Exception)
            {
                return BadRequest(ApiResponse<ServicesDto>.Error(Messages.Error.NotFound));
            }
        }
    }
}
