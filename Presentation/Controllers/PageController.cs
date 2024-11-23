using Entities.DTOs.PageDto;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Services.Extensions;
using Services.Contracts;
using Services.ResultModels.Requests;

namespace Presentation.Controllers
{
    [ApiController]
    [Route("api/Page")]
    public class PageController : ControllerBase
    {
        private readonly IServiceManager _manager;
        private readonly ILogService _logger;
        public PageController(IServiceManager manager, ILogService logger)
        {
            _manager = manager;
            _logger = logger;
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAllPagesAsync()
        {
            var page = await _manager.PageService.GetAllPagesAsync(false);
            return Ok(new GetAllRequest<IEnumerable<PageDto>>(page, 1, "Page", _logger));
        }

        [HttpGet("GetByHeader/{id:int}")]
        public async Task<IActionResult> GetPageByHeaderIdAsync([FromRoute] int id)
        {
            var page = await _manager.PageService.GetPageByHeaderIdAsync(id, false);
            return Ok(new GetRequest<PageDto>(page,2,"Page",_logger));
        }

        [HttpGet("GetByUrl/{url}")]
        public async Task<IActionResult> GetPageByHeaderURLAsync([FromRoute] string url)
        {
            var page = await _manager.PageService.GetPageByHeaderURLAsync(url, false);
            return Ok(new GetRequest<PageDto>(page,2,"Page",_logger));
        }

        [HttpGet("Get/{id:int}")]
        public async Task<IActionResult> GetPageByIdAsync([FromRoute] int id)
        {
            var page = await _manager.PageService.GetPageByIdAsync(id, false);
            return Ok(new GetRequest<PageDto>(page,2,"Page",_logger));
        }

        [Authorize(AuthenticationSchemes = "Bearer")]
        [HttpPost("Create")]
        public async Task<IActionResult> CreatePageAsync(IFormFile? file, [FromForm] PageDtoForInsertion pageDtoForInsertion)
        {
            var rnd = new Random();
            var imgId = rnd.Next(0, 100000);
            var upload = file != null ? await FileManager.FileUpload(file, imgId, "images") : null;

            pageDtoForInsertion.FileName = file != null ? $"{imgId}_{upload["FilesName"]}" : null;
            pageDtoForInsertion.FilePath = file != null ? $"{upload["FilesPath"]}" : null;
            pageDtoForInsertion.FileFullPath = file != null ? $"{upload["FilesFullPath"]}" : null;

            var page = await _manager.PageService.CreatePageAsync(pageDtoForInsertion);
            return Ok(new CreateRequest<PageDto>(page, 3, "Page", _logger));
        }

        [Authorize(AuthenticationSchemes = "Bearer")]
        [HttpPut("Update")]
        public async Task<IActionResult> UpdatePageAsync(IFormFile? file, [FromForm] PageDtoForUpdate pageDtoForUpdate)
        {
            var rnd = new Random();
            var imgId = rnd.Next(0, 100000);
            
            var data = await _manager.PageService.GetPageByIdAsync(pageDtoForUpdate.PageID, false);
            
            var upload = file != null ? await FileManager.FileUpload(file, imgId, "images") : null;
        
            pageDtoForUpdate.FileName = file != null ? $"{imgId}_{upload["FilesName"]}" : data.FileName;
            pageDtoForUpdate.FilePath = file != null ? $"{upload["FilesPath"]}" : data.FilePath;
            pageDtoForUpdate.FileFullPath = file != null ? $"{upload["FilesFullPath"]}" : data.FileFullPath;
        
            var page = await _manager.PageService.UpdatePageAsync(pageDtoForUpdate.PageID, pageDtoForUpdate, false);
            return Ok(new UpdateRequest<PageDto>(page, 4, "Page", _logger));
        }

        [Authorize(AuthenticationSchemes = "Bearer")]
        [HttpDelete("Delete/{id:int}")]
        public async Task<IActionResult> DeletePageAsync([FromRoute] int id)
        {
            var page = await _manager.PageService.DeletePageAsync(id, false);
            return Ok(new DeleteRequest<PageDto>(page, 5, "Page", _logger));
        }
    }
}
