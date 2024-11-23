﻿using Entities.DTOs.FormDto;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Services.Contracts;
using Services.ResultModels.Requests;

namespace Presentation.Controllers
{
    [ApiController]
    [Route("api/Form")]
    public class FormController : ControllerBase
    {
        private readonly IServiceManager _manager;
        private readonly ILogService _logger;
        public FormController(IServiceManager manager, ILogService logger)
        {
            _manager = manager;
            _logger = logger;
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAllFormsAsync()
        {
            var form = await _manager.FormService.GetAllFormsAsync(false);
            return Ok(new GetAllRequest<IEnumerable<FormDto>>(form, 1, "Form", _logger));
        }

        [HttpGet("Get/{id:int}")]
        public async Task<IActionResult> GetFormByIdAsync([FromRoute]int id)
        {
            var form = await _manager.FormService.GetFormByIdAsync(id, false);
            return Ok(new GetRequest<FormDto>(form, 2, "Form", _logger));
        }

        [Authorize(AuthenticationSchemes = "Bearer")]
        [HttpPost("Create")]
        public async Task<IActionResult> CreateFormAsync([FromBody] FormDtoForInsertion formDtoForInsertion)
        {
            var form = await _manager.FormService.CreateFormAsync(formDtoForInsertion);
            return Ok(new CreateRequest<FormDto>(form, 3, "Form", _logger));
        }

        [Authorize(AuthenticationSchemes = "Bearer")]
        [HttpPut("Update/{id:int}")]
        public async Task<IActionResult> UpdateFormAsync([FromRoute] int id, [FromBody] FormDtoForUpdate formDtoForUpdate)
        {
            var form = await _manager.FormService.UpdateFormAsync(id, formDtoForUpdate,false);
            return Ok(new UpdateRequest<FormDto>(form, 4, "Form", _logger));
        }

        [Authorize(AuthenticationSchemes = "Bearer")]
        [HttpDelete("Delete/{id:int}")]
        public async Task<IActionResult> DeleteFormAsync([FromRoute]int id)
        {
            var form = await _manager.FormService.DeleteFormAsync(id,false);
            return Ok(new DeleteRequest<FormDto>(form, 5, "Form", _logger));
        }
    }
}