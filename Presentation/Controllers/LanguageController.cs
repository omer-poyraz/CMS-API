using System.Text.Json;
using Entities.DTOs.LanguageDto;
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
    [Route("api/Language")]
    public class LanguageController : ControllerBase
    {
        private readonly IServiceManager _manager;

        public LanguageController(IServiceManager manager)
        {
            _manager = manager;
        }

        [HttpGet("GetAll")]
        // [AuthorizePermission("Language", "Read")]
        public async Task<IActionResult> GetAllLanguagesAsync()
        {
            try
            {
                var users = await _manager.LanguageService.GetAllLanguagesAsync(false);
                return Ok(
                    ApiResponse<IEnumerable<LanguageDto>>.Success(users, Messages.Success.Listed)
                );
            }
            catch (Exception ex)
            {
                return BadRequest(
                    ApiResponse<IEnumerable<LanguageDto>>.Error(Messages.Error.ServerError)
                );
            }
        }

        [HttpGet("Get/{id:int}")]
        // [AuthorizePermission("Language", "Read")]
        public async Task<IActionResult> GetOneLanguageByIdAsync([FromRoute] int id)
        {
            try
            {
                var user = await _manager.LanguageService.GetLanguageByIdAsync(id, false);
                return Ok(ApiResponse<LanguageDto>.Success(user, Messages.Success.Retrieved));
            }
            catch (System.Exception)
            {
                return BadRequest(ApiResponse<LanguageDto>.Error(Messages.Error.NotFound));
            }
        }

        [HttpPost("Create")]
        [AuthorizePermission("Language", "Write")]
        public async Task<IActionResult> CreateOneLanguageAsync(
            IFormFile? file,
            [FromForm] LanguageDtoForInsertion languageDtoForInsertion
        )
        {
            try
            {
                var rnd = new Random();
                var imgId = rnd.Next(0, 100000);
                if (file != null)
                {
                    var newList = new List<IFormFile> { file };
                    var uploadResults = await FileManager.FileUpload(newList, imgId, "Language");
                    var filePaths = uploadResults
                        .Select(uploadResult => uploadResult["FilesFullPath"].ToString())
                        .ToList();
                    languageDtoForInsertion.File = filePaths[0];
                }
                var user = await _manager.LanguageService.CreateLanguageAsync(
                    languageDtoForInsertion
                );
                return Ok(ApiResponse<LanguageDto>.Success(user, Messages.Success.Created));
            }
            catch (System.Exception)
            {
                return BadRequest(ApiResponse<LanguageDto>.Error(Messages.Error.NotFound));
            }
        }

        [HttpPut("Update")]
        // [AuthorizePermission("Language", "Write")]
        public async Task<IActionResult> UpdateOneUserAsync(
            IFormFile? file,
            [FromForm] LanguageDtoForUpdate languageDtoForUpdate
        )
        {
            try
            {
                var rnd = new Random();
                var imgId = rnd.Next(0, 100000);
                if (file != null)
                {
                    var newList = new List<IFormFile> { file };
                    var uploadResults = await FileManager.FileUpload(newList, imgId, "Language");
                    var filePaths = uploadResults
                        .Select(uploadResult => uploadResult["FilesFullPath"].ToString())
                        .ToList();
                    languageDtoForUpdate.File = filePaths[0];
                }
                var user = await _manager.LanguageService.UpdateLanguageAsync(
                    languageDtoForUpdate.ID,
                    languageDtoForUpdate,
                    false
                );
                return Ok(ApiResponse<LanguageDto>.Success(user, Messages.Success.Updated));
            }
            catch (System.Exception)
            {
                return BadRequest(ApiResponse<LanguageDto>.Error(Messages.Error.NotFound));
            }
        }

        [HttpDelete("Delete/{id:int}")]
        [AuthorizePermission("Language", "Delete")]
        public async Task<IActionResult> DeleteOneLanguageAsync([FromRoute] int id)
        {
            try
            {
                var user = await _manager.LanguageService.DeleteLanguageAsync(id, false);
                return Ok(ApiResponse<LanguageDto>.Success(user, Messages.Success.Deleted));
            }
            catch (System.Exception)
            {
                return BadRequest(ApiResponse<LanguageDto>.Error(Messages.Error.NotFound));
            }
        }
    }
}
