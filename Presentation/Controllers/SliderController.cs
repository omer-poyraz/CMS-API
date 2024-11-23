using Entities.DTOs.SliderDto;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Services.Extensions;
using Services.Contracts;
using Services.ResultModels.Requests;

namespace Presentation.Controllers
{
    [ApiController]
    [Route("api/Slider")]
    public class SliderController : ControllerBase
    {
        private readonly IServiceManager _manager;
        private readonly ILogService _logger;
        public SliderController(IServiceManager manager, ILogService logger)
        {
            _manager = manager;
            _logger = logger;
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAllSlidersAsync()
        {
            var slider = await _manager.SliderService.GetAllSlidersAsync(false);
            return Ok(new GetAllRequest<IEnumerable<SliderDto>>(slider, 1, "Slider", _logger));
        }

        [HttpGet("GetAllByGroup/{id:int}")]
        public async Task<IActionResult> GetAllSlidersAsync([FromRoute] int id)
        {
            var slider = await _manager.SliderService.GetAllSlidersByGroupAsync(id, false);
            return Ok(new GetAllRequest<IEnumerable<SliderDto>>(slider, 1, "Slider", _logger));
        }

        [HttpGet("Get/{id:int}")]
        public async Task<IActionResult> GetSliderByIdAsync([FromRoute] int id)
        {
            var slider = await _manager.SliderService.GetSliderByIdAsync(id, false);
            return Ok(new GetRequest<SliderDto>(slider,2,"Slider",_logger));
        }

        [Authorize(AuthenticationSchemes = "Bearer")]
        [HttpPost("Create")]
        public async Task<IActionResult> CreateSliderAsync(IFormFile? file, [FromForm] SliderDtoForInsertion sliderDtoForInsertion)
        {
            var rnd = new Random();
            var imgId = rnd.Next(0, 100000);
            var upload = file != null ? await FileManager.FileUpload(file, imgId, "images") : null;

            sliderDtoForInsertion.FileName = file != null ? $"{imgId}_{upload["FilesName"]}" : null;
            sliderDtoForInsertion.FilePath = file != null ? $"{upload["FilesPath"]}" : null;
            sliderDtoForInsertion.FileFullPath = file != null ? $"{upload["FilesFullPath"]}" : null;

            var slider = await _manager.SliderService.CreateSliderAsync(sliderDtoForInsertion);
            return Ok(new CreateRequest<SliderDto>(slider, 3, "Slider", _logger));
        }

        [Authorize(AuthenticationSchemes = "Bearer")]
        [HttpPut("Update")]
        public async Task<IActionResult> UpdateSliderAsync(IFormFile? file, [FromForm] SliderDtoForUpdate sliderDtoForUpdate)
        {
            var rnd = new Random();
            var imgId = rnd.Next(0, 100000);
            
            var data = await _manager.SliderService.GetSliderByIdAsync(sliderDtoForUpdate.SliderID, false);
            
            var upload = file != null ? await FileManager.FileUpload(file, imgId, "images") : null;
        
            sliderDtoForUpdate.FileName = file != null ? $"{imgId}_{upload["FilesName"]}" : data.FileName;
            sliderDtoForUpdate.FilePath = file != null ? $"{upload["FilesPath"]}" : data.FilePath;
            sliderDtoForUpdate.FileFullPath = file != null ? $"{upload["FilesFullPath"]}" : data.FileFullPath;
        
            var slider = await _manager.SliderService.UpdateSliderAsync(sliderDtoForUpdate.SliderID, sliderDtoForUpdate, false);
            return Ok(new UpdateRequest<SliderDto>(slider, 4, "Slider", _logger));
        }

        [Authorize(AuthenticationSchemes = "Bearer")]
        [HttpDelete("Delete/{id:int}")]
        public async Task<IActionResult> DeleteSliderAsync([FromRoute] int id)
        {
            var slider = await _manager.SliderService.DeleteSliderAsync(id, false);
            return Ok(new DeleteRequest<SliderDto>(slider, 5, "Slider", _logger));
        }
    }
}
