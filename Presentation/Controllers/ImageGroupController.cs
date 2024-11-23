using Entities.DTOs.ImageGroupDto;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Services.Contracts;
using Services.ResultModels.Requests;

namespace Presentation.Controllers
{
    [ApiController]
    [Route("api/ImageGroup")]
    public class ImageGroupController : ControllerBase
    {
        private readonly IServiceManager _manager;
        private readonly ILogService _logger;
        public ImageGroupController(IServiceManager manager, ILogService logger)
        {
            _manager = manager;
            _logger = logger;
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAllImageGroupsAsync()
        {
            var imageGroup = await _manager.ImageGroupService.GetAllImageGroupsAsync(false);
            return Ok(new GetAllRequest<IEnumerable<ImageGroupDto>>(imageGroup, 1, "ImageGroup", _logger));
        }

        [HttpGet("Get/{id:int}")]
        public async Task<IActionResult> GetImageGroupByIdAsync([FromRoute]int id)
        {
            var imageGroup = await _manager.ImageGroupService.GetImageGroupByIdAsync(id, false);
            return Ok(new GetRequest<ImageGroupDto>(imageGroup, 2, "ImageGroup", _logger));
        }

        [HttpGet("Sort/{id:int}/{newSort:int}")]
        public async Task<IActionResult> SortImageGroupAsync([FromRoute]int id, int newSort)
        {
            var imageGroup = await _manager.ImageGroupService.SortImageGroupAsync(id, newSort, false);
            return Ok(new GetRequest<ImageGroupDto>(imageGroup, 2, "ImageGroup", _logger));
        }

        [Authorize(AuthenticationSchemes = "Bearer")]
        [HttpPost("Create")]
        public async Task<IActionResult> CreateImageGroupAsync([FromBody] ImageGroupDtoForInsertion imageGroupDtoForInsertion)
        {
            var imageGroup = await _manager.ImageGroupService.CreateImageGroupAsync(imageGroupDtoForInsertion);
            return Ok(new CreateRequest<ImageGroupDto>(imageGroup, 3, "ImageGroup", _logger));
        }

        [Authorize(AuthenticationSchemes = "Bearer")]
        [HttpPut("Update")]
        public async Task<IActionResult> UpdateImageGroupAsync([FromBody] ImageGroupDtoForUpdate imageGroupDtoForUpdate)
        {
            var imageGroup = await _manager.ImageGroupService.UpdateImageGroupAsync(imageGroupDtoForUpdate.ImageGroupID, imageGroupDtoForUpdate,false);
            return Ok(new UpdateRequest<ImageGroupDto>(imageGroup, 4, "ImageGroup", _logger));
        }

        [Authorize(AuthenticationSchemes = "Bearer")]
        [HttpDelete("Delete/{id:int}")]
        public async Task<IActionResult> DeleteImageGroupAsync([FromRoute]int id)
        {
            var imageGroup = await _manager.ImageGroupService.DeleteImageGroupAsync(id,false);
            return Ok(new DeleteRequest<ImageGroupDto>(imageGroup, 5, "ImageGroup", _logger));
        }
    }
}
