using Entities.DTOs.SettingDto;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services.Contracts;
using Services.Extensions;
using Services.ResultModels.Requests;

namespace Presentation.Controllers
{
    [ApiController]
    [Route("api/Setting")]
    public class SettingController : ControllerBase
    {
        private readonly IServiceManager _manager;
        private readonly ILogService _logger;

        public SettingController(IServiceManager manager, ILogService logger)
        {
            _manager = manager;
            _logger = logger;
        }

        [HttpGet("GetAll")]
        [AuthorizePermission("Setting", "Read")]
        public async Task<IActionResult> GetAllSettingsAsync()
        {
            var sett = await _manager.SettingService.GetAllSettingsAsync(false);
            return Ok(new GetAllRequest<IEnumerable<SettingDto>>(sett, 1, "Setting", _logger));
        }

        [HttpGet("Get/{id:int}")]
        [AuthorizePermission("Setting", "Read")]
        public async Task<IActionResult> GetSettingByIdAsync([FromRoute] int id)
        {
            var sett = await _manager.SettingService.GetSettingByIdAsync(id, false);
            return Ok(new GetRequest<SettingDto>(sett, 2, "Setting", _logger));
        }

        [HttpPost("Create")]
        [AuthorizePermission("Setting", "Write")]
        public async Task<IActionResult> CreateSettingAsync(
            IFormFile? file,
            [FromForm] SettingDtoForInsertion settingDtoForInsertion
        )
        {
            var rnd = new Random();
            var imgId = rnd.Next(0, 100000);
            var upload = file != null ? await FileManager.FileUpload(file, imgId, "images") : null;

            settingDtoForInsertion.FileName =
                file != null ? $"{imgId}_{upload["FilesName"]}" : null;
            settingDtoForInsertion.FilePath = file != null ? $"{upload["FilesPath"]}" : null;
            settingDtoForInsertion.FileFullPath =
                file != null ? $"{upload["FilesFullPath"]}" : null;

            var sett = await _manager.SettingService.CreateSettingAsync(settingDtoForInsertion);
            return Ok(new CreateRequest<SettingDto>(sett, 3, "Setting", _logger));
        }

        [HttpPut("Update")]
        [AuthorizePermission("Setting", "Write")]
        public async Task<IActionResult> UpdateSettingAsync(
            IFormFile? file,
            [FromForm] SettingDtoForUpdate settingDtoForUpdate
        )
        {
            var rnd = new Random();
            var imgId = rnd.Next(0, 100000);

            var setting = await _manager.SettingService.GetSettingByIdAsync(
                settingDtoForUpdate.SettingID,
                false
            );

            var upload = file != null ? await FileManager.FileUpload(file, imgId, "images") : null;

            settingDtoForUpdate.FileName =
                file != null ? $"{imgId}_{upload["FilesName"]}" : setting.FileName;
            settingDtoForUpdate.FilePath =
                file != null ? $"{upload["FilesPath"]}" : setting.FilePath;
            settingDtoForUpdate.FileFullPath =
                file != null ? $"{upload["FilesFullPath"]}" : setting.FileFullPath;

            var sett = await _manager.SettingService.UpdateSettingAsync(
                settingDtoForUpdate.SettingID,
                settingDtoForUpdate,
                false
            );
            return Ok(new UpdateRequest<SettingDto>(sett, 4, "Setting", _logger));
        }

        [HttpDelete("Delete/{id:int}")]
        [AuthorizePermission("Setting", "Delete")]
        public async Task<IActionResult> DeleteSettingAsync([FromRoute] int id)
        {
            var sett = await _manager.SettingService.DeleteSettingAsync(id, false);
            return Ok(new DeleteRequest<SettingDto>(sett, 5, "Setting", _logger));
        }
    }
}
