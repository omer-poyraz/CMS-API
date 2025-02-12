using System.Text.Json;
using Entities.DTOs.ModuleFieldDto;
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
    [Route("api/ModuleField")]
    public class ModuleFieldController : ControllerBase
    {
        private readonly IServiceManager _manager;

        public ModuleFieldController(IServiceManager manager)
        {
            _manager = manager;
        }

        [HttpGet("GetAll")]
        // [AuthorizePermission("ModuleField", "Read")]
        public async Task<IActionResult> GetAllModuleFieldsAsync()
        {
            try
            {
                var users = await _manager.ModuleFieldService.GetAllModuleFieldsAsync(false);
                return Ok(
                    ApiResponse<IEnumerable<ModuleFieldDto>>.Success(users, Messages.Success.Listed)
                );
            }
            catch (Exception ex)
            {
                return BadRequest(
                    ApiResponse<IEnumerable<ModuleFieldDto>>.Error(Messages.Error.ServerError)
                );
            }
        }

        [HttpGet("Get/{id:int}")]
        // [AuthorizePermission("ModuleField", "Read")]
        public async Task<IActionResult> GetOneModuleFieldByIdAsync([FromRoute] int id)
        {
            try
            {
                var user = await _manager.ModuleFieldService.GetModuleFieldByIdAsync(id, false);
                return Ok(ApiResponse<ModuleFieldDto>.Success(user, Messages.Success.Retrieved));
            }
            catch (System.Exception)
            {
                return BadRequest(ApiResponse<ModuleFieldDto>.Error(Messages.Error.NotFound));
            }
        }

        [HttpGet("GetSlug/{slug}")]
        // [AuthorizePermission("ModuleField", "Read")]
        public async Task<IActionResult> GetOneModuleFieldBySlugAsync([FromRoute] string slug)
        {
            try
            {
                var user = await _manager.ModuleFieldService.GetModuleFieldBySlugAsync(slug, false);
                return Ok(ApiResponse<ModuleFieldDto>.Success(user, Messages.Success.Retrieved));
            }
            catch (System.Exception)
            {
                return BadRequest(ApiResponse<ModuleFieldDto>.Error(Messages.Error.NotFound));
            }
        }

        [HttpPost("Create")]
        [AuthorizePermission("ModuleField", "Write")]
        public async Task<IActionResult> CreateOneModuleFieldAsync(
            IFormCollection form,
            [FromForm] ModuleFieldDtoForInsertion moduleFieldDtoForInsertion
        )
        {
            try
            {
                moduleFieldDtoForInsertion.FieldName = JsonSerializer.Deserialize<
                    Dictionary<string, string>
                >(form["FieldName"]);
                moduleFieldDtoForInsertion.Slug = JsonSerializer.Deserialize<
                    Dictionary<string, string>
                >(form["Slug"]);
                var rnd = new Random();
                var imgId = rnd.Next(0, 100000);
                if (
                    moduleFieldDtoForInsertion.file != null
                    && moduleFieldDtoForInsertion.file.Any()
                )
                {
                    var uploadResults = await FileManager.FileUpload(
                        moduleFieldDtoForInsertion.file,
                        imgId,
                        "ModuleField"
                    );
                    var filePaths = uploadResults
                        .Select(uploadResult => uploadResult["FilesFullPath"].ToString())
                        .ToList();
                    moduleFieldDtoForInsertion.Files = filePaths;
                }
                var user = await _manager.ModuleFieldService.CreateModuleFieldAsync(
                    moduleFieldDtoForInsertion
                );
                return Ok(ApiResponse<ModuleFieldDto>.Success(user, Messages.Success.Created));
            }
            catch (System.Exception)
            {
                return BadRequest(ApiResponse<ModuleFieldDto>.Error(Messages.Error.NotFound));
            }
        }

        [HttpPut("Update")]
        [AuthorizePermission("ModuleField", "Write")]
        public async Task<IActionResult> UpdateOneUserAsync(
            IFormCollection form,
            [FromForm] ModuleFieldDtoForUpdate moduleFieldDtoForUpdate
        )
        {
            try
            {
                moduleFieldDtoForUpdate.FieldName = JsonSerializer.Deserialize<
                    Dictionary<string, string>
                >(form["FieldName"]);
                moduleFieldDtoForUpdate.Slug = JsonSerializer.Deserialize<
                    Dictionary<string, string>
                >(form["Slug"]);
                if (moduleFieldDtoForUpdate.file != null && moduleFieldDtoForUpdate.file.Any())
                {
                    var rnd = new Random();
                    var imgId = rnd.Next(0, 100000);
                    var uploadResults = await FileManager.FileUpload(
                        moduleFieldDtoForUpdate.file,
                        imgId,
                        "ModuleField"
                    );
                    var filePaths = uploadResults
                        .Select(uploadResult => uploadResult["FilesFullPath"].ToString())
                        .ToList();
                    moduleFieldDtoForUpdate.Files = filePaths;
                }
                var user = await _manager.ModuleFieldService.UpdateModuleFieldAsync(
                    moduleFieldDtoForUpdate.ID,
                    moduleFieldDtoForUpdate,
                    false
                );
                return Ok(ApiResponse<ModuleFieldDto>.Success(user, Messages.Success.Updated));
            }
            catch (System.Exception)
            {
                return BadRequest(ApiResponse<ModuleFieldDto>.Error(Messages.Error.NotFound));
            }
        }

        [HttpPut("Sort")]
        [AuthorizePermission("Module", "Write")]
        public async Task<IActionResult> SortOneUserAsync(int id, int sort)
        {
            try
            {
                var user = await _manager.ModuleFieldService.SortModuleFieldAsync(id, sort, false);
                return Ok(ApiResponse<ModuleFieldDto>.Success(user, Messages.Success.Updated));
            }
            catch (System.Exception)
            {
                return BadRequest(ApiResponse<ModuleFieldDto>.Error(Messages.Error.NotFound));
            }
        }

        [HttpDelete("Delete/{id:int}")]
        [AuthorizePermission("ModuleField", "Delete")]
        public async Task<IActionResult> DeleteOneModuleFieldAsync([FromRoute] int id)
        {
            try
            {
                var user = await _manager.ModuleFieldService.DeleteModuleFieldAsync(id, false);
                return Ok(ApiResponse<ModuleFieldDto>.Success(user, Messages.Success.Deleted));
            }
            catch (System.Exception)
            {
                return BadRequest(ApiResponse<ModuleFieldDto>.Error(Messages.Error.NotFound));
            }
        }
    }
}
