using Entities.DTOs.DealerDto;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Services.Contracts;
using Services.ResultModels.Requests;

namespace Presentation.Controllers
{
    [ApiController]
    [Route("api/Dealer")]
    public class DealerController : ControllerBase
    {
        private readonly IServiceManager _manager;
        private readonly ILogService _logger;
        public DealerController(IServiceManager manager, ILogService logger)
        {
            _manager = manager;
            _logger = logger;
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAllDealersAsync()
        {
            var dealer = await _manager.DealerService.GetAllDealersAsync(false);
            return Ok(new GetAllRequest<IEnumerable<DealerDto>>(dealer, 1, "Dealer", _logger));
        }

        [HttpGet("GetAllByContact/{id:int}")]
        public async Task<IActionResult> GetAllDealersByContactAsync([FromRoute] int id)
        {
            var dealer = await _manager.DealerService.GetAllDealersByContactAsync(id, false);
            return Ok(new GetAllRequest<IEnumerable<DealerDto>>(dealer, 1, "Dealer", _logger));
        }

        [HttpGet("Get/{id:int}")]
        public async Task<IActionResult> GetDealerByIdAsync([FromRoute]int id)
        {
            var dealer = await _manager.DealerService.GetDealerByIdAsync(id, false);
            return Ok(new GetRequest<DealerDto>(dealer, 2, "Dealer", _logger));
        }

        [Authorize(AuthenticationSchemes = "Bearer")]
        [HttpPost("Create")]
        public async Task<IActionResult> CreateDealerAsync([FromBody] DealerDtoForInsertion dealerDtoForInsertion)
        {
            var dealer = await _manager.DealerService.CreateDealerAsync(dealerDtoForInsertion);
            return Ok(new CreateRequest<DealerDto>(dealer, 3, "Dealer", _logger));
        }

        [Authorize(AuthenticationSchemes = "Bearer")]
        [HttpPut("Update/{id:int}")]
        public async Task<IActionResult> UpdateDealerAsync([FromRoute] int id, [FromBody] DealerDtoForUpdate dealerDtoForUpdate)
        {
            var dealer = await _manager.DealerService.UpdateDealerAsync(id, dealerDtoForUpdate,false);
            return Ok(new UpdateRequest<DealerDto>(dealer, 4, "Dealer", _logger));
        }

        [Authorize(AuthenticationSchemes = "Bearer")]
        [HttpDelete("Delete/{id:int}")]
        public async Task<IActionResult> DeleteDealerAsync([FromRoute]int id)
        {
            var dealer = await _manager.DealerService.DeleteDealerAsync(id,false);
            return Ok(new DeleteRequest<DealerDto>(dealer, 5, "Dealer", _logger));
        }
    }
}
