using Entities.DTOs.HeaderDto;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services.Contracts;
using Services.Extensions;
using Services.ResultModels.Requests;

namespace Presentation.Controllers
{
    [ApiController]
    [Route("api/Header")]
    public class HeaderController : ControllerBase
    {
        private readonly IServiceManager _manager;
        private readonly ILogService _logger;

        public HeaderController(IServiceManager manager, ILogService logger)
        {
            _manager = manager;
            _logger = logger;
        }

        [HttpGet("GetAll")]
        [AuthorizePermission("Header", "Read")]
        public async Task<IActionResult> GetAllHeaderAsync()
        {
            var header = await _manager.HeaderService.GetAllHeadersAsync(false);
            return Ok(new GetAllRequest<IEnumerable<HeaderDto>>(header, 1, "Header", _logger));
        }

        [HttpGet("Get/{id:int}")]
        [AuthorizePermission("Header", "Read")]
        public async Task<IActionResult> GetHeaderByIdAsync([FromRoute] int id)
        {
            var header = await _manager.HeaderService.GetHeaderByIdAsync(id, false);
            return Ok(new GetRequest<HeaderDto>(header, 2, "Header", _logger));
        }

        [HttpGet("Sort/{id:int}/{newSort:int}")]
        [AuthorizePermission("Header", "Read")]
        public async Task<IActionResult> SortHeaderAsync([FromRoute] int id, int newSort)
        {
            var header = await _manager.HeaderService.SortHeaderAsync(id, newSort, false);
            return Ok(new GetRequest<HeaderDto>(header, 2, "Header", _logger));
        }

        [HttpPost("Create")]
        [AuthorizePermission("Header", "Write")]
        public async Task<IActionResult> CreateHeaderAsync(
            IFormFile? file,
            [FromForm] HeaderDtoForInsertion headerDtoForInsertion
        )
        {
            var rnd = new Random();
            var imgId = rnd.Next(0, 100000);
            var upload = file != null ? await FileManager.FileUpload(file, imgId, "images") : null;

            headerDtoForInsertion.FileName = file != null ? $"{imgId}_{upload["FilesName"]}" : null;
            headerDtoForInsertion.FilePath = file != null ? $"{upload["FilesPath"]}" : null;
            headerDtoForInsertion.FileFullPath = file != null ? $"{upload["FilesFullPath"]}" : null;

            var header = await _manager.HeaderService.CreateHeaderAsync(headerDtoForInsertion);
            return Ok(new CreateRequest<HeaderDto>(header, 3, "Header", _logger));
        }

        [HttpPut("Update")]
        [AuthorizePermission("Header", "Write")]
        public async Task<IActionResult> UpdateHeaderAsync(
            IFormFile? file,
            [FromForm] HeaderDtoForUpdate headerDtoForUpdate
        )
        {
            var rnd = new Random();
            var imgId = rnd.Next(0, 100000);
            var upload = file != null ? await FileManager.FileUpload(file, imgId, "images") : null;

            headerDtoForUpdate.FileName = file != null ? $"{imgId}_{upload["FilesName"]}" : null;
            headerDtoForUpdate.FilePath = file != null ? $"{upload["FilesPath"]}" : null;
            headerDtoForUpdate.FileFullPath = file != null ? $"{upload["FilesFullPath"]}" : null;

            var header = await _manager.HeaderService.UpdateHeaderAsync(
                headerDtoForUpdate.HeaderID,
                headerDtoForUpdate,
                false
            );
            return Ok(new UpdateRequest<HeaderDto>(header, 4, "Header", _logger));
        }

        [HttpDelete("Delete/{id:int}")]
        [AuthorizePermission("Header", "Delete")]
        public async Task<IActionResult> DeleteHeaderAsync([FromRoute] int id)
        {
            var header = await _manager.HeaderService.DeleteHeaderAsync(id, false);
            return Ok(new DeleteRequest<HeaderDto>(header, 5, "Header", _logger));
        }
    }
}
