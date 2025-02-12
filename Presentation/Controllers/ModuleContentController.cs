using System.Text.Json;
using Entities.DTOs.ModuleContentDto;
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
    [Route("api/ModuleContent")]
    public class ModuleContentController : ControllerBase
    {
        private readonly IServiceManager _manager;

        public ModuleContentController(IServiceManager manager)
        {
            _manager = manager;
        }

        [HttpGet("GetAll")]
        // [AuthorizePermission("ModuleContent", "Read")]
        public async Task<IActionResult> GetAllModuleContentsAsync()
        {
            try
            {
                var users = await _manager.ModuleContentService.GetAllModuleContentsAsync(false);
                return Ok(
                    ApiResponse<IEnumerable<ModuleContentDto>>.Success(
                        users,
                        Messages.Success.Listed
                    )
                );
            }
            catch (Exception ex)
            {
                return BadRequest(
                    ApiResponse<IEnumerable<ModuleContentDto>>.Error(Messages.Error.ServerError)
                );
            }
        }

        [HttpGet("Get/{id:int}")]
        // [AuthorizePermission("ModuleContent", "Read")]
        public async Task<IActionResult> GetOneModuleContentByIdAsync([FromRoute] int id)
        {
            try
            {
                var user = await _manager.ModuleContentService.GetModuleContentByIdAsync(id, false);
                return Ok(ApiResponse<ModuleContentDto>.Success(user, Messages.Success.Retrieved));
            }
            catch (System.Exception)
            {
                return BadRequest(ApiResponse<ModuleContentDto>.Error(Messages.Error.NotFound));
            }
        }

        [HttpGet("GetSlug/{slug}")]
        // [AuthorizePermission("ModuleContent", "Read")]
        public async Task<IActionResult> GetOneModuleContentBySlugAsync([FromRoute] string slug)
        {
            try
            {
                var user = await _manager.ModuleContentService.GetModuleContentBySlugAsync(
                    slug,
                    false
                );
                return Ok(ApiResponse<ModuleContentDto>.Success(user, Messages.Success.Retrieved));
            }
            catch (System.Exception)
            {
                return BadRequest(ApiResponse<ModuleContentDto>.Error(Messages.Error.NotFound));
            }
        }

        [HttpPost("Create")]
        [AuthorizePermission("ModuleContent", "Write")]
        public async Task<IActionResult> CreateOneModuleContentAsync(
            IFormCollection form,
            [FromForm] ModuleContentDtoForInsertion moduleContentDtoForInsertion
        )
        {
            try
            {
                moduleContentDtoForInsertion.Text = JsonSerializer.Deserialize<
                    Dictionary<string, string>
                >(form["Text"]);
                moduleContentDtoForInsertion.Slug = JsonSerializer.Deserialize<
                    Dictionary<string, string>
                >(form["Slug"]);
                var rnd = new Random();
                var imgId = rnd.Next(0, 100000);
                if (moduleContentDtoForInsertion.file.Count() > 0)
                {
                    var uploadResults = await FileManager.FileUpload(
                        moduleContentDtoForInsertion.file,
                        imgId,
                        "ModuleContent"
                    );
                    var filePaths = uploadResults
                        .Select(uploadResult => uploadResult["FilesFullPath"].ToString())
                        .ToList();
                    moduleContentDtoForInsertion.Files = filePaths;
                }
                var user = await _manager.ModuleContentService.CreateModuleContentAsync(
                    moduleContentDtoForInsertion
                );
                return Ok(ApiResponse<ModuleContentDto>.Success(user, Messages.Success.Created));
            }
            catch (System.Exception)
            {
                return BadRequest(ApiResponse<ModuleContentDto>.Error(Messages.Error.NotFound));
            }
        }

        [HttpPut("Update")]
        [AuthorizePermission("ModuleContent", "Write")]
        public async Task<IActionResult> UpdateOneUserAsync(
            IFormCollection form,
            [FromForm] ModuleContentDtoForUpdate moduleContentDtoForUpdate
        )
        {
            try
            {
                moduleContentDtoForUpdate.Text = JsonSerializer.Deserialize<
                    Dictionary<string, string>
                >(form["Text"]);
                moduleContentDtoForUpdate.Slug = JsonSerializer.Deserialize<
                    Dictionary<string, string>
                >(form["Slug"]);
                var rnd = new Random();
                var imgId = rnd.Next(0, 100000);
                if (moduleContentDtoForUpdate.file.Count() > 0)
                {
                    var uploadResults = await FileManager.FileUpload(
                        moduleContentDtoForUpdate.file,
                        imgId,
                        "ModuleContent"
                    );
                    var filePaths = uploadResults
                        .Select(uploadResult => uploadResult["FilesFullPath"].ToString())
                        .ToList();
                    moduleContentDtoForUpdate.Files = filePaths;
                }
                var user = await _manager.ModuleContentService.UpdateModuleContentAsync(
                    moduleContentDtoForUpdate.ID,
                    moduleContentDtoForUpdate,
                    false
                );
                return Ok(ApiResponse<ModuleContentDto>.Success(user, Messages.Success.Updated));
            }
            catch (System.Exception)
            {
                return BadRequest(ApiResponse<ModuleContentDto>.Error(Messages.Error.NotFound));
            }
        }

        [HttpPut("Sort")]
        [AuthorizePermission("Module", "Write")]
        public async Task<IActionResult> SortOneUserAsync(int id, int sort)
        {
            try
            {
                var user = await _manager.ModuleContentService.SortModuleContentAsync(
                    id,
                    sort,
                    false
                );
                return Ok(ApiResponse<ModuleContentDto>.Success(user, Messages.Success.Updated));
            }
            catch (System.Exception)
            {
                return BadRequest(ApiResponse<ModuleContentDto>.Error(Messages.Error.NotFound));
            }
        }

        [HttpDelete("Delete/{id:int}")]
        [AuthorizePermission("ModuleContent", "Delete")]
        public async Task<IActionResult> DeleteOneModuleContentAsync([FromRoute] int id)
        {
            try
            {
                var user = await _manager.ModuleContentService.DeleteModuleContentAsync(id, false);
                return Ok(ApiResponse<ModuleContentDto>.Success(user, Messages.Success.Deleted));
            }
            catch (System.Exception)
            {
                return BadRequest(ApiResponse<ModuleContentDto>.Error(Messages.Error.NotFound));
            }
        }
    }
}
