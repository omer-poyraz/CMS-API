using Entities.DTOs.ContactDto;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Services.Contracts;
using Services.Extensions;
using Services.ResultModels.Requests;

namespace Presentation.Controllers
{
    [ApiController]
    [Route("api/Contact")]
    public class ContactController : ControllerBase
    {
        private readonly IServiceManager _manager;
        private readonly ILogService _logger;

        public ContactController(IServiceManager manager, ILogService logger)
        {
            _manager = manager;
            _logger = logger;
        }

        [HttpGet("GetAll")]
        [AuthorizePermission("Contact", "Read")]
        public async Task<IActionResult> GetAllContactsAsync()
        {
            var contact = await _manager.ContactService.GetAllContactsAsync(false);
            return Ok(new GetAllRequest<IEnumerable<ContactDto>>(contact, 1, "Contact", _logger));
        }

        [HttpGet("Get/{id:int}")]
        [AuthorizePermission("Contact", "Read")]
        public async Task<IActionResult> GetContactByIdAsync([FromRoute] int id)
        {
            var contact = await _manager.ContactService.GetContactByIdAsync(id, false);
            return Ok(new GetRequest<ContactDto>(contact, 2, "Contact", _logger));
        }

        [HttpPost("Create")]
        [AuthorizePermission("Contact", "Write")]
        public async Task<IActionResult> CreateContactAsync(
            [FromBody] ContactDtoForInsertion contactDtoForInsertion
        )
        {
            var contact = await _manager.ContactService.CreateContactAsync(contactDtoForInsertion);
            return Ok(new CreateRequest<ContactDto>(contact, 3, "Contact", _logger));
        }

        [HttpPut("Update/{id:int}")]
        [AuthorizePermission("Contact", "Write")]
        public async Task<IActionResult> UpdateContactAsync(
            [FromRoute] int id,
            [FromBody] ContactDtoForUpdate contactDtoForUpdate
        )
        {
            var contact = await _manager.ContactService.UpdateContactAsync(
                id,
                contactDtoForUpdate,
                false
            );
            return Ok(new UpdateRequest<ContactDto>(contact, 4, "Contact", _logger));
        }

        [HttpDelete("Delete/{id:int}")]
        [AuthorizePermission("Contact", "Delete")]
        public async Task<IActionResult> DeleteContactAsync([FromRoute] int id)
        {
            var contact = await _manager.ContactService.DeleteContactAsync(id, false);
            return Ok(new DeleteRequest<ContactDto>(contact, 5, "Contact", _logger));
        }
    }
}
