using System.Text.Json;
using Entities.DTOs.FormResponseDto;
using Entities.RequestFeature.User;
using Entities.Response;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services.Contracts;
using Services.Extensions;
using Services.ResultModels.Requests;

namespace Presentation.Controllers
{
    [ApiController]
    [Route("api/FormResponse")]
    public class FormResponseController : ControllerBase
    {
        private readonly IServiceManager _manager;

        public FormResponseController(IServiceManager manager)
        {
            _manager = manager;
        }

        [HttpGet("GetAll")]
        [AuthorizePermission("FormResponse", "Read")]
        public async Task<IActionResult> GetAllFormResponsesAsync()
        {
            try
            {
                var users = await _manager.FormResponseService.GetAllFormResponsesAsync(false);
                return Ok(
                    ApiResponse<IEnumerable<FormResponseDto>>.Success(
                        users,
                        Messages.Success.Listed
                    )
                );
            }
            catch (Exception ex)
            {
                return BadRequest(
                    ApiResponse<IEnumerable<FormResponseDto>>.Error(Messages.Error.ServerError)
                );
            }
        }

        [HttpGet("Get/{id:int}")]
        [AuthorizePermission("FormResponse", "Read")]
        public async Task<IActionResult> GetOneFormResponseByIdAsync([FromRoute] int id)
        {
            try
            {
                var user = await _manager.FormResponseService.GetFormResponseByIdAsync(id, false);
                return Ok(ApiResponse<FormResponseDto>.Success(user, Messages.Success.Retrieved));
            }
            catch (System.Exception)
            {
                return BadRequest(ApiResponse<FormResponseDto>.Error(Messages.Error.NotFound));
            }
        }

        [HttpGet("GetForm/{formId:int}")]
        [AuthorizePermission("FormResponse", "Read")]
        public async Task<IActionResult> GetOneFormResponseByFormAsync([FromRoute] int formId)
        {
            try
            {
                var user = await _manager.FormResponseService.GetFormResponseByFormAsync(
                    formId,
                    false
                );
                return Ok(ApiResponse<FormResponseDto>.Success(user, Messages.Success.Retrieved));
            }
            catch (System.Exception)
            {
                return BadRequest(ApiResponse<FormResponseDto>.Error(Messages.Error.NotFound));
            }
        }

        [HttpPost("Create")]
        [AuthorizePermission("FormResponse", "Write")]
        public async Task<IActionResult> CreateOneFormResponseAsync(
            ICollection<IFormFile>? file,
            [FromForm] FormResponseDtoForInsertion formResponseDtoForInsertion
        )
        {
            try
            {
                var rnd = new Random();
                var imgId = rnd.Next(0, 100000);
                if (file != null)
                {
                    var uploadResults = await FileManager.FileUpload(file, imgId, "FormResponse");
                    var filePaths = uploadResults
                        .Select(uploadResult => uploadResult["FilesFullPath"].ToString())
                        .ToList();
                    formResponseDtoForInsertion.files = filePaths;
                }
                var user = await _manager.FormResponseService.CreateFormResponseAsync(
                    formResponseDtoForInsertion
                );
                return Ok(ApiResponse<FormResponseDto>.Success(user, Messages.Success.Created));
            }
            catch (System.Exception)
            {
                return BadRequest(ApiResponse<FormResponseDto>.Error(Messages.Error.NotFound));
            }
        }

        [HttpDelete("Delete/{id:int}")]
        [AuthorizePermission("FormResponse", "Delete")]
        public async Task<IActionResult> DeleteOneFormResponseAsync([FromRoute] int id)
        {
            try
            {
                var user = await _manager.FormResponseService.DeleteFormResponseAsync(id, false);
                return Ok(ApiResponse<FormResponseDto>.Success(user, Messages.Success.Deleted));
            }
            catch (System.Exception)
            {
                return BadRequest(ApiResponse<FormResponseDto>.Error(Messages.Error.NotFound));
            }
        }
    }
}
