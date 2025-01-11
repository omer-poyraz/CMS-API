using System.Text.Json;
using Entities.DTOs.SocialDto;
using Entities.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services.Contracts;
using Services.Extensions;
using Services.ResultModels.Requests;

namespace Presentation.Controllers
{
    [ApiController]
    [Route("api/Social")]
    public class SocialController : ControllerBase
    {
        private readonly IServiceManager _manager;
        private readonly ILogService _logger;

        public SocialController(IServiceManager manager, ILogService logger)
        {
            _manager = manager;
            _logger = logger;
        }

        [HttpGet("GetAll")]
        [AuthorizePermission("Social", "Read")]
        public async Task<IActionResult> GetAllSocialsAsync()
        {
            var socials = await _manager.SocialService.GetAllSocialsAsync(false);
            return Ok(new GetAllRequest<IEnumerable<SocialDto>>(socials, 1, "Social", _logger));
        }

        [HttpGet("GetAllBySocial/{id:int}")]
        [AuthorizePermission("Social", "Read")]
        public async Task<IActionResult> GetAllSocialsBySocialAsync([FromRoute] int id)
        {
            var socials = await _manager.SocialService.GetAllSocialsBySocialAsync(id, false);
            return Ok(new GetAllRequest<IEnumerable<SocialDto>>(socials, 1, "Social", _logger));
        }

        [HttpGet("Get/{id:int}")]
        [AuthorizePermission("Social", "Read")]
        public async Task<IActionResult> GetSocialByIdAsync([FromRoute] int id)
        {
            var socials = await _manager.SocialService.GetSocialByIdAsync(id, false);
            return Ok(new GetRequest<SocialDto>(socials, 2, "Social", _logger));
        }

        [HttpPost("Create")]
        [AuthorizePermission("Social", "Write")]
        public async Task<IActionResult> CreateSocialAsync(
            IFormFile? file,
            [FromForm] SocialDtoForInsertion socialsDtoForInsertion
        )
        {
            var rnd = new Random();

            var imgId = rnd.Next(0, 100000);
            var upload = file != null ? await FileManager.FileUpload(file, imgId, "images") : null;

            socialsDtoForInsertion.FileName =
                file != null ? $"{imgId}_{upload["FilesName"]}" : null;
            socialsDtoForInsertion.FilePath = file != null ? $"{upload["FilesPath"]}" : null;
            socialsDtoForInsertion.FileFullPath =
                file != null ? $"{upload["FilesFullPath"]}" : null;

            var socials = await _manager.SocialService.CreateSocialAsync(socialsDtoForInsertion);
            return Ok(new CreateRequest<SocialDto>(socials, 3, "Social", _logger));
        }

        [HttpPut("Update")]
        [AuthorizePermission("Social", "Write")]
        public async Task<IActionResult> UpdateSocialAsync(
            IFormFile? file,
            [FromForm] SocialDtoForUpdate socialsDtoForUpdate
        )
        {
            var cat = await _manager.SocialService.GetSocialByIdAsync(
                socialsDtoForUpdate.SocialID,
                false
            );
            var rnd = new Random();
            var imgId = rnd.Next(0, 100000);
            var upload = file != null ? await FileManager.FileUpload(file, imgId, "images") : null;

            socialsDtoForUpdate.FileName =
                file != null ? $"{imgId}_{upload["FilesName"]}" : cat.FileName;
            socialsDtoForUpdate.FilePath = file != null ? $"{upload["FilesPath"]}" : cat.FilePath;
            socialsDtoForUpdate.FileFullPath =
                file != null ? $"{upload["FilesFullPath"]}" : cat.FileFullPath;

            var socials = await _manager.SocialService.UpdateSocialAsync(
                socialsDtoForUpdate.SocialID,
                socialsDtoForUpdate,
                false
            );
            return Ok(new UpdateRequest<SocialDto>(socials, 4, "Social", _logger));
        }

        [HttpDelete("Delete/{id:int}")]
        [AuthorizePermission("Social", "Delete")]
        public async Task<IActionResult> DeleteSocialAsync([FromRoute] int id)
        {
            var socials = await _manager.SocialService.DeleteSocialAsync(id, false);
            return Ok(new DeleteRequest<SocialDto>(socials, 5, "Social", _logger));
        }
    }
}
