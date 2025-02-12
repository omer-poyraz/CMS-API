using System.Text.Json;
using Entities.DTOs.FormDto;
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
    [Route("api/Form")]
    public class FormController : ControllerBase
    {
        private readonly IServiceManager _manager;

        public FormController(IServiceManager manager)
        {
            _manager = manager;
        }

        [HttpGet("GetAll")]
        // [AuthorizePermission("Form", "Read")]
        public async Task<IActionResult> GetAllFormsAsync()
        {
            try
            {
                var users = await _manager.FormService.GetAllFormsAsync(false);
                return Ok(
                    ApiResponse<IEnumerable<FormDto>>.Success(users, Messages.Success.Listed)
                );
            }
            catch (Exception ex)
            {
                return BadRequest(
                    ApiResponse<IEnumerable<FormDto>>.Error(Messages.Error.ServerError)
                );
            }
        }

        [HttpGet("Get/{id:int}")]
        // [AuthorizePermission("Form", "Read")]
        public async Task<IActionResult> GetOneFormByIdAsync([FromRoute] int id)
        {
            try
            {
                var user = await _manager.FormService.GetFormByIdAsync(id, false);
                return Ok(ApiResponse<FormDto>.Success(user, Messages.Success.Retrieved));
            }
            catch (System.Exception)
            {
                return BadRequest(ApiResponse<FormDto>.Error(Messages.Error.NotFound));
            }
        }

        [HttpGet("GetSlug/{slug}")]
        // [AuthorizePermission("Form", "Read")]
        public async Task<IActionResult> GetOneFormBySlugAsync([FromRoute] string slug)
        {
            try
            {
                var user = await _manager.FormService.GetFormBySlugAsync(slug, false);
                return Ok(ApiResponse<FormDto>.Success(user, Messages.Success.Retrieved));
            }
            catch (System.Exception)
            {
                return BadRequest(ApiResponse<FormDto>.Error(Messages.Error.NotFound));
            }
        }

        [HttpPost("Create")]
        [AuthorizePermission("Form", "Write")]
        public async Task<IActionResult> CreateOneFormAsync(
            ICollection<IFormFile>? file,
            [FromForm] FormDtoForInsertion formDtoForInsertion
        )
        {
            try
            {
                var rnd = new Random();
                var imgId = rnd.Next(0, 100000);
                if (file != null)
                {
                    var uploadResults = await FileManager.FileUpload(file, imgId, "Form");
                    var filePaths = uploadResults
                        .Select(uploadResult => uploadResult["FilesFullPath"].ToString())
                        .ToList();
                    formDtoForInsertion.files = filePaths;
                }
                var user = await _manager.FormService.CreateFormAsync(formDtoForInsertion);
                return Ok(ApiResponse<FormDto>.Success(user, Messages.Success.Created));
            }
            catch (System.Exception)
            {
                return BadRequest(ApiResponse<FormDto>.Error(Messages.Error.NotFound));
            }
        }

        [HttpPut("Update")]
        // [AuthorizePermission("Form", "Write")]
        public async Task<IActionResult> UpdateOneUserAsync(
            ICollection<IFormFile>? file,
            [FromForm] FormDtoForUpdate formDtoForUpdate
        )
        {
            try
            {
                var rnd = new Random();
                var imgId = rnd.Next(0, 100000);
                if (file.Count() > 0)
                {
                    var uploadResults = await FileManager.FileUpload(file, imgId, "Form");
                    var filePaths = uploadResults
                        .Select(uploadResult => uploadResult["FilesFullPath"].ToString())
                        .ToList();
                    formDtoForUpdate.files = filePaths;
                }
                var user = await _manager.FormService.UpdateFormAsync(
                    formDtoForUpdate.ID,
                    formDtoForUpdate,
                    false
                );
                return Ok(ApiResponse<FormDto>.Success(user, Messages.Success.Updated));
            }
            catch (System.Exception)
            {
                return BadRequest(ApiResponse<FormDto>.Error(Messages.Error.NotFound));
            }
        }

        [HttpDelete("Delete/{id:int}")]
        [AuthorizePermission("Form", "Delete")]
        public async Task<IActionResult> DeleteOneFormAsync([FromRoute] int id)
        {
            try
            {
                var user = await _manager.FormService.DeleteFormAsync(id, false);
                return Ok(ApiResponse<FormDto>.Success(user, Messages.Success.Deleted));
            }
            catch (System.Exception)
            {
                return BadRequest(ApiResponse<FormDto>.Error(Messages.Error.NotFound));
            }
        }
    }
}
