using Entities.DTOs.SocialMediaDto;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services.Contracts;
using Services.Extensions;
using Services.ResultModels.Requests;

namespace Presentation.Controllers
{
    [ApiController]
    [Route("api/SocialMedia")]
    public class SocialMediaController : ControllerBase
    {
        private readonly IServiceManager _manager;
        private readonly ILogService _logger;

        public SocialMediaController(IServiceManager manager, ILogService logger)
        {
            _manager = manager;
            _logger = logger;
        }

        [HttpGet("GetAll")]
        [AuthorizePermission("SocialMedia", "Read")]
        public async Task<IActionResult> GetAllSocialMediasAsync()
        {
            var socialMedia = await _manager.SocialMediaService.GetAllSocialMediasAsync(false);
            return Ok(
                new GetAllRequest<IEnumerable<SocialMediaDto>>(
                    socialMedia,
                    1,
                    "SocialMedia",
                    _logger
                )
            );
        }

        [HttpGet("Get/{id:int}")]
        [AuthorizePermission("SocialMedia", "Read")]
        public async Task<IActionResult> GetSocialMediaByIdAsync([FromRoute] int id)
        {
            var socialMedia = await _manager.SocialMediaService.GetSocialMediaByIdAsync(id, false);
            return Ok(new GetRequest<SocialMediaDto>(socialMedia, 2, "SocialMedia", _logger));
        }

        [HttpPost("Create")]
        [AuthorizePermission("SocialMedia", "Write")]
        public async Task<IActionResult> CreateSocialMediaAsync(
            [FromBody] SocialMediaDtoForInsertion socialMediaDtoForInsertion
        )
        {
            var socialMedia = await _manager.SocialMediaService.CreateSocialMediaAsync(
                socialMediaDtoForInsertion
            );
            return Ok(new CreateRequest<SocialMediaDto>(socialMedia, 3, "SocialMedia", _logger));
        }

        [HttpPut("Update/{id:int}")]
        [AuthorizePermission("SocialMedia", "Write")]
        public async Task<IActionResult> UpdateSocialMediaAsync(
            [FromRoute] int id,
            [FromBody] SocialMediaDtoForUpdate socialMediaDtoForUpdate
        )
        {
            var socialMedia = await _manager.SocialMediaService.UpdateSocialMediaAsync(
                id,
                socialMediaDtoForUpdate,
                false
            );
            return Ok(new UpdateRequest<SocialMediaDto>(socialMedia, 4, "SocialMedia", _logger));
        }

        [HttpDelete("Delete/{id:int}")]
        [AuthorizePermission("SocialMedia", "Delete")]
        public async Task<IActionResult> DeleteSocialMediaAsync([FromRoute] int id)
        {
            var socialMedia = await _manager.SocialMediaService.DeleteSocialMediaAsync(id, false);
            return Ok(new DeleteRequest<SocialMediaDto>(socialMedia, 5, "SocialMedia", _logger));
        }
    }
}
