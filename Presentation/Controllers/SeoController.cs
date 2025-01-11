using Entities.DTOs.SeoDto;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Services.Contracts;
using Services.Extensions;
using Services.ResultModels.Requests;

namespace Presentation.Controllers
{
    [ApiController]
    [Route("api/Seo")]
    public class SeoController : ControllerBase
    {
        private readonly IServiceManager _manager;
        private readonly ILogService _logger;

        public SeoController(IServiceManager manager, ILogService logger)
        {
            _manager = manager;
            _logger = logger;
        }

        [HttpGet("GetAll")]
        [AuthorizePermission("Seo", "Read")]
        public async Task<IActionResult> GetAllSeosAsync()
        {
            var seo = await _manager.SeoService.GetAllSeosAsync(false);
            return Ok(new GetAllRequest<IEnumerable<SeoDto>>(seo, 1, "Seo", _logger));
        }

        [HttpGet("Get/{id:int}")]
        [AuthorizePermission("Seo", "Read")]
        public async Task<IActionResult> GetSeoByIdAsync([FromRoute] int id)
        {
            var seo = await _manager.SeoService.GetSeoByIdAsync(id, false);
            return Ok(new GetRequest<SeoDto>(seo, 2, "Seo", _logger));
        }

        [HttpPost("Create")]
        [AuthorizePermission("Seo", "Write")]
        public async Task<IActionResult> CreateSeoAsync(
            [FromBody] SeoDtoForInsertion seoDtoForInsertion
        )
        {
            var seo = await _manager.SeoService.CreateSeoAsync(seoDtoForInsertion);
            return Ok(new CreateRequest<SeoDto>(seo, 3, "Seo", _logger));
        }

        [HttpPut("Update")]
        [AuthorizePermission("Seo", "Write")]
        public async Task<IActionResult> UpdateSeoAsync([FromBody] SeoDtoForUpdate seoDtoForUpdate)
        {
            var seo = await _manager.SeoService.UpdateSeoAsync(
                seoDtoForUpdate.SeoID,
                seoDtoForUpdate,
                false
            );
            return Ok(new UpdateRequest<SeoDto>(seo, 4, "Seo", _logger));
        }

        [HttpDelete("Delete/{id:int}")]
        [AuthorizePermission("Seo", "Delete")]
        public async Task<IActionResult> DeleteSeoAsync([FromRoute] int id)
        {
            var seo = await _manager.SeoService.DeleteSeoAsync(id, false);
            return Ok(new DeleteRequest<SeoDto>(seo, 5, "Seo", _logger));
        }
    }
}
