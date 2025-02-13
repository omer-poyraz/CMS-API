using System.Text.Json;
using Entities.DTOs.SettingsDto;
using Entities.Response;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services.Contracts;
using Services.Extensions;

namespace Presentation.Controllers
{
    [ApiController]
    [Route("api/Settings")]
    public class SettingsController : ControllerBase
    {
        private readonly IServiceManager _manager;

        public SettingsController(IServiceManager manager)
        {
            _manager = manager;
        }

        [HttpGet("GetAll")]
        // [AuthorizePermission("Settings", "Read")]
        public async Task<IActionResult> GetAllSettingssAsync()
        {
            try
            {
                var users = await _manager.SettingsService.GetAllSettingsAsync(false);
                return Ok(
                    ApiResponse<IEnumerable<SettingsDto>>.Success(users, Messages.Success.Listed)
                );
            }
            catch (Exception)
            {
                return BadRequest(
                    ApiResponse<IEnumerable<SettingsDto>>.Error(Messages.Error.ServerError)
                );
            }
        }

        [HttpGet("Get/{id:int}")]
        // [AuthorizePermission("Settings", "Read")]
        public async Task<IActionResult> GetOneSettingsByIdAsync([FromRoute] int id)
        {
            try
            {
                var user = await _manager.SettingsService.GetSettingsByIdAsync(id, false);
                return Ok(ApiResponse<SettingsDto>.Success(user, Messages.Success.Retrieved));
            }
            catch (System.Exception)
            {
                return BadRequest(ApiResponse<SettingsDto>.Error(Messages.Error.NotFound));
            }
        }

        [HttpGet("GetSlug/{slug}")]
        // [AuthorizePermission("Settings", "Read")]
        public async Task<IActionResult> GetOneSettingsBySiteAsync([FromRoute] string site)
        {
            try
            {
                var user = await _manager.SettingsService.GetSettingsBySiteAsync(site, false);
                return Ok(ApiResponse<SettingsDto>.Success(user, Messages.Success.Retrieved));
            }
            catch (System.Exception)
            {
                return BadRequest(ApiResponse<SettingsDto>.Error(Messages.Error.NotFound));
            }
        }

        [HttpPost("Create")]
        [AuthorizePermission("Settings", "Write")]
        public async Task<IActionResult> CreateOneSettingsAsync(
            IFormCollection form,
            [FromForm] SettingsDtoForInsertion settingsDtoForInsertion
        )
        {
            try
            {
                settingsDtoForInsertion.Name = JsonSerializer.Deserialize<Dictionary<string, string>>(form["Name"]);
                settingsDtoForInsertion.Phone = JsonSerializer.Deserialize<Dictionary<string, string>>(form["Phone"]);
                settingsDtoForInsertion.Address = JsonSerializer.Deserialize<Dictionary<string, string>>(form["Address"]);
                settingsDtoForInsertion.Fax = JsonSerializer.Deserialize<Dictionary<string, string>>(form["Fax"]);
                settingsDtoForInsertion.Country = JsonSerializer.Deserialize<Dictionary<string, string>>(form["Country"]);
                settingsDtoForInsertion.City = JsonSerializer.Deserialize<Dictionary<string, string>>(form["City"]);
                settingsDtoForInsertion.District = JsonSerializer.Deserialize<Dictionary<string, string>>(form["District"]);
                if (settingsDtoForInsertion.file != null && settingsDtoForInsertion.file.Any())
                {
                    var rnd = new Random();
                    var imgId = rnd.Next(0, 100000);
                    var uploadResults = await FileManager.FileUpload(
                        settingsDtoForInsertion.file,
                        imgId,
                        "Settings"
                    );
                    var filePaths = uploadResults
                        .Select(uploadResult => uploadResult["FilesFullPath"].ToString())
                        .ToList();
                    settingsDtoForInsertion.Files = filePaths;
                }
                var user = await _manager.SettingsService.CreateSettingsAsync(settingsDtoForInsertion);
                return Ok(ApiResponse<SettingsDto>.Success(user, Messages.Success.Created));
            }
            catch (System.Exception)
            {
                return BadRequest(ApiResponse<SettingsDto>.Error(Messages.Error.NotFound));
            }
        }

        [HttpPut("Update")]
        [AuthorizePermission("Settings", "Write")]
        public async Task<IActionResult> UpdateOneUserAsync(
            IFormCollection form,
            [FromForm] SettingsDtoForUpdate settingsDtoForUpdate
        )
        {
            try
            {
                settingsDtoForUpdate.Name = JsonSerializer.Deserialize<Dictionary<string, string>>(form["Name"]);
                settingsDtoForUpdate.Phone = JsonSerializer.Deserialize<Dictionary<string, string>>(form["Phone"]);
                settingsDtoForUpdate.Address = JsonSerializer.Deserialize<Dictionary<string, string>>(form["Address"]);
                settingsDtoForUpdate.Fax = JsonSerializer.Deserialize<Dictionary<string, string>>(form["Fax"]);
                settingsDtoForUpdate.Country = JsonSerializer.Deserialize<Dictionary<string, string>>(form["Country"]);
                settingsDtoForUpdate.City = JsonSerializer.Deserialize<Dictionary<string, string>>(form["City"]);
                settingsDtoForUpdate.District = JsonSerializer.Deserialize<Dictionary<string, string>>(form["District"]);
                if (settingsDtoForUpdate.file != null && settingsDtoForUpdate.file.Any())
                {
                    var rnd = new Random();
                    var imgId = rnd.Next(0, 100000);
                    var uploadResults = await FileManager.FileUpload(
                        settingsDtoForUpdate.file,
                        imgId,
                        "Settings"
                    );
                    var filePaths = uploadResults
                        .Select(uploadResult => uploadResult["FilesFullPath"].ToString())
                        .ToList();
                    settingsDtoForUpdate.Files = filePaths;
                }
                var user = await _manager.SettingsService.UpdateSettingsAsync(
                    settingsDtoForUpdate.ID,
                    settingsDtoForUpdate,
                    false
                );
                return Ok(ApiResponse<SettingsDto>.Success(user, Messages.Success.Updated));
            }
            catch (System.Exception)
            {
                return BadRequest(ApiResponse<SettingsDto>.Error(Messages.Error.NotFound));
            }
        }

        [HttpDelete("Delete/{id:int}")]
        [AuthorizePermission("Settings", "Delete")]
        public async Task<IActionResult> DeleteOneSettingsAsync([FromRoute] int id)
        {
            try
            {
                var user = await _manager.SettingsService.DeleteSettingsAsync(id, false);
                return Ok(ApiResponse<SettingsDto>.Success(user, Messages.Success.Deleted));
            }
            catch (System.Exception)
            {
                return BadRequest(ApiResponse<SettingsDto>.Error(Messages.Error.NotFound));
            }
        }
    }
}
