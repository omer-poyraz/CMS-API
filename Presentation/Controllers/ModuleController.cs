using System.Text.Json;
using Entities.DTOs.ModuleDto;
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
    [Route("api/Module")]
    public class ModuleController : ControllerBase
    {
        private readonly IServiceManager _manager;

        public ModuleController(IServiceManager manager)
        {
            _manager = manager;
        }

        [HttpGet("GetAll")]
        // [AuthorizePermission("Module", "Read")]
        public async Task<IActionResult> GetAllModulesAsync()
        {
            try
            {
                var users = await _manager.ModuleService.GetAllModulesAsync(false);
                return Ok(
                    ApiResponse<IEnumerable<ModuleDto>>.Success(users, Messages.Success.Listed)
                );
            }
            catch (Exception ex)
            {
                return BadRequest(
                    ApiResponse<IEnumerable<ModuleDto>>.Error(Messages.Error.ServerError)
                );
            }
        }

        [HttpGet("Get/{id:int}")]
        // [AuthorizePermission("Module", "Read")]
        public async Task<IActionResult> GetOneModuleByIdAsync([FromRoute] int id)
        {
            try
            {
                var user = await _manager.ModuleService.GetModuleByIdAsync(id, false);
                return Ok(ApiResponse<ModuleDto>.Success(user, Messages.Success.Retrieved));
            }
            catch (System.Exception)
            {
                return BadRequest(ApiResponse<ModuleDto>.Error(Messages.Error.NotFound));
            }
        }

        [HttpGet("GetSlug/{slug}")]
        // [AuthorizePermission("Module", "Read")]
        public async Task<IActionResult> GetOneModuleBySlugAsync([FromRoute] string slug)
        {
            try
            {
                var user = await _manager.ModuleService.GetModuleBySlugAsync(slug, false);
                return Ok(ApiResponse<ModuleDto>.Success(user, Messages.Success.Retrieved));
            }
            catch (System.Exception)
            {
                return BadRequest(ApiResponse<ModuleDto>.Error(Messages.Error.NotFound));
            }
        }

        [HttpPost("Create")]
        // [AuthorizePermission("Module", "Write")]
        public async Task<IActionResult> CreateOneModuleAsync(
            IFormCollection form,
            [FromForm] ModuleDtoForInsertion moduleDtoForInsertion
        )
        {
            try
            {
                moduleDtoForInsertion.Name = JsonSerializer.Deserialize<Dictionary<string, string>>(
                    form["Name"]
                );
                moduleDtoForInsertion.Slug = JsonSerializer.Deserialize<Dictionary<string, string>>(
                    form["Slug"]
                );
                var rnd = new Random();
                var imgId = rnd.Next(0, 100000);
                if (moduleDtoForInsertion.file.Count() > 0)
                {
                    var uploadResults = await FileManager.FileUpload(
                        moduleDtoForInsertion.file,
                        imgId,
                        "Module"
                    );
                    var filePaths = uploadResults
                        .Select(uploadResult => uploadResult["FilesFullPath"].ToString())
                        .ToList();
                    moduleDtoForInsertion.Files = filePaths;
                }
                var user = await _manager.ModuleService.CreateModuleAsync(moduleDtoForInsertion);
                return Ok(ApiResponse<ModuleDto>.Success(user, Messages.Success.Created));
            }
            catch (System.Exception)
            {
                return BadRequest(ApiResponse<ModuleDto>.Error(Messages.Error.NotFound));
            }
        }

        [HttpPut("Update")]
        [AuthorizePermission("Module", "Write")]
        public async Task<IActionResult> UpdateOneUserAsync(
            IFormCollection form,
            [FromForm] ModuleDtoForUpdate moduleDtoForUpdate
        )
        {
            try
            {
                moduleDtoForUpdate.Name = JsonSerializer.Deserialize<Dictionary<string, string>>(
                    form["Name"]
                );
                moduleDtoForUpdate.Slug = JsonSerializer.Deserialize<Dictionary<string, string>>(
                    form["Slug"]
                );
                var rnd = new Random();
                var imgId = rnd.Next(0, 100000);
                if (moduleDtoForUpdate.file.Count() > 0)
                {
                    var uploadResults = await FileManager.FileUpload(
                        moduleDtoForUpdate.file,
                        imgId,
                        "Module"
                    );
                    var filePaths = uploadResults
                        .Select(uploadResult => uploadResult["FilesFullPath"].ToString())
                        .ToList();
                    moduleDtoForUpdate.Files = filePaths;
                }
                var user = await _manager.ModuleService.UpdateModuleAsync(
                    moduleDtoForUpdate.ID,
                    moduleDtoForUpdate,
                    false
                );
                return Ok(ApiResponse<ModuleDto>.Success(user, Messages.Success.Updated));
            }
            catch (System.Exception)
            {
                return BadRequest(ApiResponse<ModuleDto>.Error(Messages.Error.NotFound));
            }
        }

        [HttpPut("Sort")]
        [AuthorizePermission("Module", "Write")]
        public async Task<IActionResult> SortOneUserAsync(int id, int sort)
        {
            try
            {
                var user = await _manager.ModuleService.SortModuleAsync(id, sort, false);
                return Ok(ApiResponse<ModuleDto>.Success(user, Messages.Success.Updated));
            }
            catch (System.Exception)
            {
                return BadRequest(ApiResponse<ModuleDto>.Error(Messages.Error.NotFound));
            }
        }

        [HttpDelete("Delete/{id:int}")]
        [AuthorizePermission("Module", "Delete")]
        public async Task<IActionResult> DeleteOneModuleAsync([FromRoute] int id)
        {
            try
            {
                var user = await _manager.ModuleService.DeleteModuleAsync(id, false);
                return Ok(ApiResponse<ModuleDto>.Success(user, Messages.Success.Deleted));
            }
            catch (System.Exception)
            {
                return BadRequest(ApiResponse<ModuleDto>.Error(Messages.Error.NotFound));
            }
        }
    }
}
