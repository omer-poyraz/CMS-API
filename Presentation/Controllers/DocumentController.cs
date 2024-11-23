using Entities.DTOs.DocumentDto;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Services.Extensions;
using Services.Contracts;
using Services.ResultModels.Requests;

namespace Presentation.Controllers
{
    [ApiController]
    [Route("api/Document")]
    public class DocumentController : ControllerBase
    {
        private readonly IServiceManager _manager;
        private readonly ILogService _logger;
        public DocumentController(IServiceManager manager, ILogService logger)
        {
            _manager = manager;
            _logger = logger;
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAllDocumentsAsync()
        {
            var document = await _manager.DocumentService.GetAllDocumentsAsync(false);
            return Ok(new GetAllRequest<IEnumerable<DocumentDto>>(document, 1, "Document", _logger));
        }

        [HttpGet("GetAllByGroup/{id:int}")]
        public async Task<IActionResult> GetAllDocumentsAsync([FromRoute] int id)
        {
            var document = await _manager.DocumentService.GetAllDocumentsByGroupAsync(id, false);
            return Ok(new GetAllRequest<IEnumerable<DocumentDto>>(document, 1, "Document", _logger));
        }

        [HttpGet("Get/{id:int}")]
        public async Task<IActionResult> GetDocumentByIdAsync([FromRoute] int id)
        {
            var document = await _manager.DocumentService.GetDocumentByIdAsync(id, false);
            return Ok(new GetRequest<DocumentDto>(document,2,"Document",_logger));
        }

        [Authorize(AuthenticationSchemes = "Bearer")]
        [HttpPost("Create")]
        public async Task<IActionResult> CreateDocumentAsync(IFormFile? file, [FromForm] DocumentDtoForInsertion documentDtoForInsertion)
        {
            var rnd = new Random();
            var imgId = rnd.Next(0, 100000);
            var upload = file != null ? await FileManager.FileUpload(file, imgId, "images") : null;

            documentDtoForInsertion.FileName = file != null ? $"{imgId}_{upload["FilesName"]}" : null;
            documentDtoForInsertion.FilePath = file != null ? $"{upload["FilesPath"]}" : null;
            documentDtoForInsertion.FileFullPath = file != null ? $"{upload["FilesFullPath"]}" : null;

            var document = await _manager.DocumentService.CreateDocumentAsync(documentDtoForInsertion);
            return Ok(new CreateRequest<DocumentDto>(document, 3, "Document", _logger));
        }

        [Authorize(AuthenticationSchemes = "Bearer")]
        [HttpPut("Update")]
        public async Task<IActionResult> UpdateDocumentAsync(IFormFile? file, [FromForm] DocumentDtoForUpdate documentDtoForUpdate)
        {
            var rnd = new Random();
            var imgId = rnd.Next(0, 100000);
            
            var data = await _manager.DocumentService.GetDocumentByIdAsync(documentDtoForUpdate.DocumentID, false);
            
            var upload = file != null ? await FileManager.FileUpload(file, imgId, "images") : null;
        
            documentDtoForUpdate.FileName = file != null ? $"{imgId}_{upload["FilesName"]}" : data.FileName;
            documentDtoForUpdate.FilePath = file != null ? $"{upload["FilesPath"]}" : data.FilePath;
            documentDtoForUpdate.FileFullPath = file != null ? $"{upload["FilesFullPath"]}" : data.FileFullPath;
        
            var document = await _manager.DocumentService.UpdateDocumentAsync(documentDtoForUpdate.DocumentID, documentDtoForUpdate, false);
            return Ok(new UpdateRequest<DocumentDto>(document, 4, "Document", _logger));
        }

        [Authorize(AuthenticationSchemes = "Bearer")]
        [HttpDelete("Delete/{id:int}")]
        public async Task<IActionResult> DeleteDocumentAsync([FromRoute] int id)
        {
            var document = await _manager.DocumentService.DeleteDocumentAsync(id, false);
            return Ok(new DeleteRequest<DocumentDto>(document, 5, "Document", _logger));
        }
    }
}
