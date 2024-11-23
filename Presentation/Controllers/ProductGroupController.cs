using Entities.DTOs.ProductGroupDto;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Services.Extensions;
using Services.Contracts;
using Services.ResultModels.Requests;

namespace Presentation.Controllers
{
    [ApiController]
    [Route("api/ProductGroup")]
    public class ProductGroupController : ControllerBase
    {
        private readonly IServiceManager _manager;
        private readonly ILogService _logger;
        public ProductGroupController(IServiceManager manager, ILogService logger)
        {
            _manager = manager;
            _logger = logger;
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAllProductGroupsAsync()
        {
            var productGroup = await _manager.ProductGroupService.GetAllProductGroupsAsync(false);
            return Ok(new GetAllRequest<IEnumerable<ProductGroupDto>>(productGroup, 1, "ProductGroup", _logger));
        }

        [HttpGet("Get/{id:int}")]
        public async Task<IActionResult> GetProductGroupByIdAsync([FromRoute]int id)
        {
            var productGroup = await _manager.ProductGroupService.GetProductGroupByIdAsync(id, false);
            return Ok(new GetRequest<ProductGroupDto>(productGroup, 2, "ProductGroup", _logger));
        }

        [HttpGet("GetByHeader/{id:int}")]
        public async Task<IActionResult> GetProductGroupByHeaderIdAsync([FromRoute]int id)
        {
            var productGroup = await _manager.ProductGroupService.GetProductGroupByHeaderIdAsync(id, false);
            return Ok(new GetRequest<ProductGroupDto>(productGroup, 2, "ProductGroup", _logger));
        }

        [HttpGet("GetByUrl/{url}")]
        public async Task<IActionResult> GetProductGroupByHeaderURLAsync([FromRoute] string url)
        {
            var productGroup = await _manager.ProductGroupService.GetProductGroupByHeaderURLAsync(url, false);
            return Ok(new GetRequest<ProductGroupDto>(productGroup, 2, "ProductGroup", _logger));
        }

        [Authorize(AuthenticationSchemes = "Bearer")]
        [HttpPost("Create")]
        public async Task<IActionResult> CreateProductGroupAsync(IFormFile? file, IFormFile? file2, IFormFile? file3, [FromForm] ProductGroupDtoForInsertion productGroupDtoForInsertion)
        {
            var rnd = new Random();
            var imgId = rnd.Next(0, 100000);
            var imgId2 = rnd.Next(0, 100000);
            var imgId3 = rnd.Next(0, 100000);
            var upload = file != null ? await FileManager.FileUpload(file, imgId, "images") : null;
            var upload2 = file2 != null ? await FileManager.FileUpload(file2, imgId2, "images") : null;
            var upload3 = file3 != null ? await FileManager.FileUpload(file3, imgId3, "images") : null;

            productGroupDtoForInsertion.FileName = file != null ? $"{imgId}_{upload["FilesName"]}" : null;
            productGroupDtoForInsertion.FilePath = file != null ? $"{upload["FilesPath"]}" : null;
            productGroupDtoForInsertion.FileFullPath = file != null ? $"{upload["FilesFullPath"]}" : null;
            productGroupDtoForInsertion.FileName2 = file2 != null ? $"{imgId2}_{upload2["FilesName"]}" : null;
            productGroupDtoForInsertion.FilePath2 = file2 != null ? $"{upload2["FilesPath"]}" : null;
            productGroupDtoForInsertion.FileFullPath2 = file2 != null ? $"{upload2["FilesFullPath"]}" : null;
            productGroupDtoForInsertion.FileName3 = file3 != null ? $"{imgId3}_{upload3["FilesName"]}" : null;
            productGroupDtoForInsertion.FilePath3 = file3 != null ? $"{upload3["FilesPath"]}" : null;
            productGroupDtoForInsertion.FileFullPath3 = file3 != null ? $"{upload3["FilesFullPath"]}" : null;

            var productGroup = await _manager.ProductGroupService.CreateProductGroupAsync(productGroupDtoForInsertion);
            return Ok(new CreateRequest<ProductGroupDto>(productGroup, 3, "ProductGroup", _logger));
        }

        [Authorize(AuthenticationSchemes = "Bearer")]
        [HttpPut("Update")]
        public async Task<IActionResult> UpdateProductGroupAsync(IFormFile? file, IFormFile? file2, IFormFile? file3, [FromForm] ProductGroupDtoForUpdate productGroupDtoForUpdate)
        {
            var rnd = new Random();
            var imgId = rnd.Next(0, 100000);
            var imgId2 = rnd.Next(0, 100000);
            var imgId3 = rnd.Next(0, 100000);
            
            var data = await _manager.ProductGroupService.GetProductGroupByIdAsync(productGroupDtoForUpdate.ProductGroupID, false);
            
            var upload = file != null ? await FileManager.FileUpload(file, imgId, "images") : null;
            var upload2 = file2 != null ? await FileManager.FileUpload(file2, imgId2, "images") : null;
            var upload3 = file3 != null ? await FileManager.FileUpload(file3, imgId3, "images") : null;
        
            productGroupDtoForUpdate.FileName = file != null ? $"{imgId}_{upload["FilesName"]}" : data.FileName;
            productGroupDtoForUpdate.FilePath = file != null ? $"{upload["FilesPath"]}" : data.FilePath;
            productGroupDtoForUpdate.FileFullPath = file != null ? $"{upload["FilesFullPath"]}" : data.FileFullPath;
            productGroupDtoForUpdate.FileName2 = file2 != null ? $"{imgId2}_{upload2["FilesName"]}" : data.FileName2;
            productGroupDtoForUpdate.FilePath2 = file2 != null ? $"{upload2["FilesPath"]}" : data.FilePath2;
            productGroupDtoForUpdate.FileFullPath2 = file2 != null ? $"{upload2["FilesFullPath"]}" : data.FileFullPath2;
            productGroupDtoForUpdate.FileName3 = file3 != null ? $"{imgId3}_{upload3["FilesName"]}" : data.FileName3;
            productGroupDtoForUpdate.FilePath3 = file3 != null ? $"{upload3["FilesPath"]}" : data.FilePath3;
            productGroupDtoForUpdate.FileFullPath3 = file3 != null ? $"{upload3["FilesFullPath"]}" : data.FileFullPath3;

            var productGroup = await _manager.ProductGroupService.UpdateProductGroupAsync(productGroupDtoForUpdate.ProductGroupID, productGroupDtoForUpdate,false);
            return Ok(new UpdateRequest<ProductGroupDto>(productGroup, 4, "ProductGroup", _logger));
        }

        [Authorize(AuthenticationSchemes = "Bearer")]
        [HttpDelete("Delete/{id:int}")]
        public async Task<IActionResult> DeleteProductGroupAsync([FromRoute]int id)
        {
            var productGroup = await _manager.ProductGroupService.DeleteProductGroupAsync(id,false);
            return Ok(new DeleteRequest<ProductGroupDto>(productGroup, 5, "ProductGroup", _logger));
        }
    }
}
