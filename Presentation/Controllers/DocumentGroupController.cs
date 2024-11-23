﻿using Entities.DTOs.DocumentGroupDto;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Services.Contracts;
using Services.ResultModels.Requests;

namespace Presentation.Controllers
{
    [ApiController]
    [Route("api/DocumentGroup")]
    public class DocumentGroupController : ControllerBase
    {
        private readonly IServiceManager _manager;
        private readonly ILogService _logger;
        public DocumentGroupController(IServiceManager manager, ILogService logger)
        {
            _manager = manager;
            _logger = logger;
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAllDocumentGroupsAsync()
        {
            var documentGroup = await _manager.DocumentGroupService.GetAllDocumentGroupsAsync(false);
            return Ok(new GetAllRequest<IEnumerable<DocumentGroupDto>>(documentGroup, 1, "DocumentGroup", _logger));
        }

        [HttpGet("Get/{id:int}")]
        public async Task<IActionResult> GetDocumentGroupByIdAsync([FromRoute]int id)
        {
            var documentGroup = await _manager.DocumentGroupService.GetDocumentGroupByIdAsync(id, false);
            return Ok(new GetRequest<DocumentGroupDto>(documentGroup, 2, "DocumentGroup", _logger));
        }

        [Authorize(AuthenticationSchemes = "Bearer")]
        [HttpPost("Create")]
        public async Task<IActionResult> CreateDocumentGroupAsync([FromBody] DocumentGroupDtoForInsertion documentGroupDtoForInsertion)
        {
            var documentGroup = await _manager.DocumentGroupService.CreateDocumentGroupAsync(documentGroupDtoForInsertion);
            return Ok(new CreateRequest<DocumentGroupDto>(documentGroup, 3, "DocumentGroup", _logger));
        }

        [Authorize(AuthenticationSchemes = "Bearer")]
        [HttpPut("Update/{id:int}")]
        public async Task<IActionResult> UpdateDocumentGroupAsync([FromRoute] int id, [FromBody] DocumentGroupDtoForUpdate documentGroupDtoForUpdate)
        {
            var documentGroup = await _manager.DocumentGroupService.UpdateDocumentGroupAsync(id, documentGroupDtoForUpdate,false);
            return Ok(new UpdateRequest<DocumentGroupDto>(documentGroup, 4, "DocumentGroup", _logger));
        }

        [Authorize(AuthenticationSchemes = "Bearer")]
        [HttpDelete("Delete/{id:int}")]
        public async Task<IActionResult> DeleteDocumentGroupAsync([FromRoute]int id)
        {
            var documentGroup = await _manager.DocumentGroupService.DeleteDocumentGroupAsync(id,false);
            return Ok(new DeleteRequest<DocumentGroupDto>(documentGroup, 5, "DocumentGroup", _logger));
        }
    }
}