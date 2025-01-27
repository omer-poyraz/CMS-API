using System.Text.Json;
using Entities.DTOs.BlogDto;
using Entities.RequestFeature.User;
using Entities.Response;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services.Contracts;
using Services.Extensions;
using Services.ResultModels.Requests;

namespace Presentation.Controllers
{
    [ApiController]
    [Route("api/Blog")]
    public class BlogController : ControllerBase
    {
        private readonly IServiceManager _manager;

        public BlogController(IServiceManager manager)
        {
            _manager = manager;
        }

        [HttpGet("GetAll")]
        [AuthorizePermission("Blog", "Read")]
        public async Task<IActionResult> GetAllBlogsAsync()
        {
            try
            {
                var users = await _manager.BlogService.GetAllBlogsAsync(false);
                return Ok(
                    ApiResponse<IEnumerable<BlogDto>>.Success(users, Messages.Success.Listed)
                );
            }
            catch (Exception ex)
            {
                return BadRequest(
                    ApiResponse<IEnumerable<BlogDto>>.Error(Messages.Error.ServerError)
                );
            }
        }

        [HttpGet("Get/{id:int}")]
        [AuthorizePermission("Blog", "Read")]
        public async Task<IActionResult> GetOneBlogByIdAsync([FromRoute] int id)
        {
            try
            {
                var user = await _manager.BlogService.GetBlogByIdAsync(id, false);
                return Ok(ApiResponse<BlogDto>.Success(user, Messages.Success.Retrieved));
            }
            catch (System.Exception)
            {
                return BadRequest(ApiResponse<BlogDto>.Error(Messages.Error.NotFound));
            }
        }

        [HttpPost("Create")]
        [AuthorizePermission("Blog", "Write")]
        public async Task<IActionResult> CreateOneBlogAsync(
            ICollection<IFormFile>? files,
            [FromBody] BlogDtoForInsertion blogDtoForInsertion
        )
        {
            try
            {
                var rnd = new Random();
                var imgId = rnd.Next(0, 100000);
                if (files != null)
                {
                    var uploadResults = await FileManager.FileUpload(files, imgId, "Blog");
                    var filePaths = uploadResults
                        .Select(uploadResult => uploadResult["FilesFullPath"].ToString())
                        .ToList();
                    blogDtoForInsertion.files = filePaths;
                }
                var user = await _manager.BlogService.CreateBlogAsync(blogDtoForInsertion);
                return Ok(ApiResponse<BlogDto>.Success(user, Messages.Success.Created));
            }
            catch (System.Exception)
            {
                return BadRequest(ApiResponse<BlogDto>.Error(Messages.Error.NotFound));
            }
        }

        [HttpPut("Update")]
        [AuthorizePermission("Blog", "Write")]
        public async Task<IActionResult> UpdateOneUserAsync(
            ICollection<IFormFile>? files,
            [FromBody] BlogDtoForUpdate blogDtoForUpdate
        )
        {
            try
            {
                var rnd = new Random();
                var imgId = rnd.Next(0, 100000);
                if (files != null)
                {
                    var uploadResults = await FileManager.FileUpload(files, imgId, "Blog");
                    var filePaths = uploadResults
                        .Select(uploadResult => uploadResult["FilesFullPath"].ToString())
                        .ToList();
                    blogDtoForUpdate.files = filePaths;
                }
                var user = await _manager.BlogService.UpdateBlogAsync(
                    blogDtoForUpdate.ID,
                    blogDtoForUpdate,
                    false
                );
                return Ok(ApiResponse<BlogDto>.Success(user, Messages.Success.Updated));
            }
            catch (System.Exception)
            {
                return BadRequest(ApiResponse<BlogDto>.Error(Messages.Error.NotFound));
            }
        }

        [HttpDelete("Delete/{id:int}")]
        [AuthorizePermission("Blog", "Delete")]
        public async Task<IActionResult> DeleteOneBlogAsync([FromRoute] int id)
        {
            try
            {
                var user = await _manager.BlogService.DeleteBlogAsync(id, false);
                return Ok(ApiResponse<BlogDto>.Success(user, Messages.Success.Deleted));
            }
            catch (System.Exception)
            {
                return BadRequest(ApiResponse<BlogDto>.Error(Messages.Error.NotFound));
            }
        }
    }
}
