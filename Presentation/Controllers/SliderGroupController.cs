using Entities.DTOs.SliderGroupDto;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Services.Contracts;
using Services.Extensions;
using Services.ResultModels.Requests;

namespace Presentation.Controllers
{
    [ApiController]
    [Route("api/SliderGroup")]
    public class SliderGroupController : ControllerBase
    {
        private readonly IServiceManager _manager;
        private readonly ILogService _logger;

        public SliderGroupController(IServiceManager manager, ILogService logger)
        {
            _manager = manager;
            _logger = logger;
        }

        [HttpGet("GetAll")]
        [AuthorizePermission("SliderGroup", "Read")]
        public async Task<IActionResult> GetAllSliderGroupsAsync()
        {
            var sliderGroup = await _manager.SliderGroupService.GetAllSliderGroupsAsync(false);
            return Ok(
                new GetAllRequest<IEnumerable<SliderGroupDto>>(
                    sliderGroup,
                    1,
                    "SliderGroup",
                    _logger
                )
            );
        }

        [HttpGet("Get/{id:int}")]
        [AuthorizePermission("SliderGroup", "Read")]
        public async Task<IActionResult> GetSliderGroupByIdAsync([FromRoute] int id)
        {
            var sliderGroup = await _manager.SliderGroupService.GetSliderGroupByIdAsync(id, false);
            return Ok(new GetRequest<SliderGroupDto>(sliderGroup, 2, "SliderGroup", _logger));
        }

        [HttpPost("Create")]
        [AuthorizePermission("SliderGroup", "Write")]
        public async Task<IActionResult> CreateSliderGroupAsync(
            [FromBody] SliderGroupDtoForInsertion sliderGroupDtoForInsertion
        )
        {
            var sliderGroup = await _manager.SliderGroupService.CreateSliderGroupAsync(
                sliderGroupDtoForInsertion
            );
            return Ok(new CreateRequest<SliderGroupDto>(sliderGroup, 3, "SliderGroup", _logger));
        }

        [HttpPut("Update/{id:int}")]
        [AuthorizePermission("SliderGroup", "Write")]
        public async Task<IActionResult> UpdateSliderGroupAsync(
            [FromRoute] int id,
            [FromBody] SliderGroupDtoForUpdate sliderGroupDtoForUpdate
        )
        {
            var sliderGroup = await _manager.SliderGroupService.UpdateSliderGroupAsync(
                id,
                sliderGroupDtoForUpdate,
                false
            );
            return Ok(new UpdateRequest<SliderGroupDto>(sliderGroup, 4, "SliderGroup", _logger));
        }

        [HttpDelete("Delete/{id:int}")]
        [AuthorizePermission("SliderGroup", "Delete")]
        public async Task<IActionResult> DeleteSliderGroupAsync([FromRoute] int id)
        {
            var sliderGroup = await _manager.SliderGroupService.DeleteSliderGroupAsync(id, false);
            return Ok(new DeleteRequest<SliderGroupDto>(sliderGroup, 5, "SliderGroup", _logger));
        }
    }
}
