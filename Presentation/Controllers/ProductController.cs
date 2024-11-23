using Entities.DTOs.ProductDto;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Services.Extensions;
using Services.Contracts;
using Services.ResultModels.Requests;

namespace Presentation.Controllers
{
    [ApiController]
    [Route("api/Product")]
    public class ProductController : ControllerBase
    {
        private readonly IServiceManager _manager;
        private readonly ILogService _logger;
        public ProductController(IServiceManager manager, ILogService logger)
        {
            _manager = manager;
            _logger = logger;
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAllProductsAsync()
        {
            var product = await _manager.ProductService.GetAllProductsAsync(false);
            return Ok(new GetAllRequest<IEnumerable<ProductDto>>(product, 1, "Product", _logger));
        }

        [HttpGet("GetAllByGroup/{id:int}")]
        public async Task<IActionResult> GetAllProductsAsync([FromRoute] int id)
        {
            var product = await _manager.ProductService.GetAllProductsByGroupAsync(id, false);
            return Ok(new GetAllRequest<IEnumerable<ProductDto>>(product, 1, "Product", _logger));
        }

        [HttpGet("Get/{id:int}")]
        public async Task<IActionResult> GetProductByIdAsync([FromRoute] int id)
        {
            var product = await _manager.ProductService.GetProductByIdAsync(id, false);
            return Ok(new GetRequest<ProductDto>(product,2,"Product",_logger));
        }

        [Authorize(AuthenticationSchemes = "Bearer")]
        [HttpPost("Create")]
        public async Task<IActionResult> CreateProductAsync(IFormFile? file, [FromForm] ProductDtoForInsertion productDtoForInsertion)
        {
            var rnd = new Random();
            var imgId = rnd.Next(0, 100000);
            var upload = file != null ? await FileManager.FileUpload(file, imgId, "images") : null;

            productDtoForInsertion.FileName = file != null ? $"{imgId}_{upload["FilesName"]}" : null;
            productDtoForInsertion.FilePath = file != null ? $"{upload["FilesPath"]}" : null;
            productDtoForInsertion.FileFullPath = file != null ? $"{upload["FilesFullPath"]}" : null;

            var product = await _manager.ProductService.CreateProductAsync(productDtoForInsertion);
            return Ok(new CreateRequest<ProductDto>(product, 3, "Product", _logger));
        }

        [Authorize(AuthenticationSchemes = "Bearer")]
        [HttpPut("Update")]
        public async Task<IActionResult> UpdateProductAsync(IFormFile? file, [FromForm] ProductDtoForUpdate productDtoForUpdate)
        {
            var rnd = new Random();
            var imgId = rnd.Next(0, 100000);
            
            var data = await _manager.ProductService.GetProductByIdAsync(productDtoForUpdate.ProductID, false);
            
            var upload = file != null ? await FileManager.FileUpload(file, imgId, "images") : null;
        
            productDtoForUpdate.FileName = file != null ? $"{imgId}_{upload["FilesName"]}" : data.FileName;
            productDtoForUpdate.FilePath = file != null ? $"{upload["FilesPath"]}" : data.FilePath;
            productDtoForUpdate.FileFullPath = file != null ? $"{upload["FilesFullPath"]}" : data.FileFullPath;
        
            var product = await _manager.ProductService.UpdateProductAsync(productDtoForUpdate.ProductID, productDtoForUpdate, false);
            return Ok(new UpdateRequest<ProductDto>(product, 4, "Product", _logger));
        }

        [Authorize(AuthenticationSchemes = "Bearer")]
        [HttpDelete("Delete/{id:int}")]
        public async Task<IActionResult> DeleteProductAsync([FromRoute] int id)
        {
            var product = await _manager.ProductService.DeleteProductAsync(id, false);
            return Ok(new DeleteRequest<ProductDto>(product, 5, "Product", _logger));
        }
    }
}
