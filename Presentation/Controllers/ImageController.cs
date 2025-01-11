using Entities.DTOs.ImageDto;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Services.Contracts;
using Services.Extensions;
using Services.ResultModels.Requests;

namespace Presentation.Controllers
{
    [ApiController]
    [Route("api/Image")]
    public class ImageController : ControllerBase
    {
        private readonly IServiceManager _manager;
        private readonly ILogService _logger;

        public ImageController(IServiceManager manager, ILogService logger)
        {
            _manager = manager;
            _logger = logger;
        }

        [HttpGet("GetAll")]
        [AuthorizePermission("Image", "Read")]
        public async Task<IActionResult> GetAllImagesAsync()
        {
            var image = await _manager.ImageService.GetAllImagesAsync(false);
            return Ok(new GetAllRequest<IEnumerable<ImageDto>>(image, 1, "Image", _logger));
        }

        [HttpGet("Get/{id:int}")]
        [AuthorizePermission("Image", "Read")]
        public async Task<IActionResult> GetImageByIdAsync([FromRoute] int id)
        {
            var image = await _manager.ImageService.GetImageByIdAsync(id, false);
            return Ok(new GetRequest<ImageDto>(image, 2, "Image", _logger));
        }

        [HttpGet("Sort/{id:int}/{newSort:int}")]
        [AuthorizePermission("Image", "Read")]
        public async Task<IActionResult> SortImageAsync([FromRoute] int id, int newSort)
        {
            var image = await _manager.ImageService.SortImageAsync(id, newSort, false);
            return Ok(new GetRequest<ImageDto>(image, 2, "Image", _logger));
        }

        [HttpPost("Create")]
        [AuthorizePermission("Image", "Write")]
        public async Task<IActionResult> CreateImageAsync(
            [FromForm] ImageDtoForInsertion imageDtoForInsertion
        )
        {
            var image = await _manager.ImageService.CreateImageAsync(imageDtoForInsertion);
            return Ok(new CreateRequest<ImageDto>(image, 3, "Image", _logger));
        }

        [HttpPut("Update")]
        [AuthorizePermission("Image", "Write")]
        public async Task<IActionResult> UpdateImageAsync(
            [FromBody] ImageDtoForUpdate imageDtoForUpdate
        )
        {
            var image = await _manager.ImageService.UpdateImageAsync(
                imageDtoForUpdate.ImageID,
                imageDtoForUpdate,
                false
            );
            return Ok(new UpdateRequest<ImageDto>(image, 4, "Image", _logger));
        }

        [HttpDelete("Delete/{id:int}")]
        [AuthorizePermission("Image", "Delete")]
        public async Task<IActionResult> DeleteImageAsync([FromRoute] int id)
        {
            var image = await _manager.ImageService.DeleteImageAsync(id, false);
            return Ok(new DeleteRequest<ImageDto>(image, 5, "Image", _logger));
        }
    }
}
