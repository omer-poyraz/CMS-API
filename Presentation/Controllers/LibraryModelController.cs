using System.Text.Json;
using Entities.DTOs.LibraryModelDto;
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
    [Route("api/LibraryModel")]
    public class LibraryModelController : ControllerBase
    {
        private readonly IServiceManager _manager;

        public LibraryModelController(IServiceManager manager)
        {
            _manager = manager;
        }

        [HttpGet("GetAll")]
        // [AuthorizePermission("LibraryModel", "Read")]
        public async Task<IActionResult> GetAllLibraryModelsAsync()
        {
            try
            {
                var users = await _manager.LibraryModelService.GetAllLibraryModelsAsync(false);
                return Ok(
                    ApiResponse<IEnumerable<LibraryModelDto>>.Success(
                        users,
                        Messages.Success.Listed
                    )
                );
            }
            catch (Exception ex)
            {
                return BadRequest(
                    ApiResponse<IEnumerable<LibraryModelDto>>.Error(Messages.Error.ServerError)
                );
            }
        }

        [HttpGet("Get/{id:int}")]
        // [AuthorizePermission("LibraryModel", "Read")]
        public async Task<IActionResult> GetOneLibraryModelByIdAsync([FromRoute] int id)
        {
            try
            {
                var user = await _manager.LibraryModelService.GetLibraryModelByIdAsync(id, false);
                return Ok(ApiResponse<LibraryModelDto>.Success(user, Messages.Success.Retrieved));
            }
            catch (System.Exception)
            {
                return BadRequest(ApiResponse<LibraryModelDto>.Error(Messages.Error.NotFound));
            }
        }

        [HttpGet("GetSlug/{slug}")]
        // [AuthorizePermission("LibraryModel", "Read")]
        public async Task<IActionResult> GetOneLibraryModelBySlugAsync([FromRoute] string slug)
        {
            try
            {
                var user = await _manager.LibraryModelService.GetLibraryModelBySlugAsync(
                    slug,
                    false
                );
                return Ok(ApiResponse<LibraryModelDto>.Success(user, Messages.Success.Retrieved));
            }
            catch (System.Exception)
            {
                return BadRequest(ApiResponse<LibraryModelDto>.Error(Messages.Error.NotFound));
            }
        }

        [HttpGet("GetSite/{site}")]
        // [AuthorizePermission("LibraryModel", "Read")]
        public async Task<IActionResult> GetOneLibraryModelBySiteAsync([FromRoute] string site)
        {
            try
            {
                var user = await _manager.LibraryModelService.GetLibraryModelBySiteAsync(
                    site,
                    false
                );
                return Ok(ApiResponse<LibraryModelDto>.Success(user, Messages.Success.Retrieved));
            }
            catch (System.Exception)
            {
                return BadRequest(ApiResponse<LibraryModelDto>.Error(Messages.Error.NotFound));
            }
        }

        [HttpPost("Create")]
        [AuthorizePermission("LibraryModel", "Write")]
        public async Task<IActionResult> CreateOneLibraryModelAsync(
            IFormFile? file,
            [FromForm] LibraryModelDtoForInsertion libraryModelDtoForInsertion
        )
        {
            try
            {
                var rnd = new Random();
                var imgId = rnd.Next(0, 100000);
                if (file != null)
                {
                    var newList = new List<IFormFile>();
                    newList.Add(file);
                    var uploadResults = await FileManager.FileUpload(
                        newList,
                        imgId,
                        "LibraryModel"
                    );
                    var filePaths = uploadResults
                        .Select(uploadResult => uploadResult["FilesFullPath"].ToString())
                        .ToList();
                    libraryModelDtoForInsertion.File = filePaths[0];
                }
                var user = await _manager.LibraryModelService.CreateLibraryModelAsync(
                    libraryModelDtoForInsertion
                );
                return Ok(ApiResponse<LibraryModelDto>.Success(user, Messages.Success.Created));
            }
            catch (System.Exception)
            {
                return BadRequest(ApiResponse<LibraryModelDto>.Error(Messages.Error.NotFound));
            }
        }

        [HttpPut("Update")]
        // [AuthorizePermission("LibraryModel", "Write")]
        public async Task<IActionResult> UpdateOneUserAsync(
            IFormFile? file,
            [FromForm] LibraryModelDtoForUpdate libraryModelDtoForUpdate
        )
        {
            try
            {
                var rnd = new Random();
                var imgId = rnd.Next(0, 100000);
                if (file != null)
                {
                    var newList = new List<IFormFile>();
                    newList.Add(file);
                    var uploadResults = await FileManager.FileUpload(
                        newList,
                        imgId,
                        "LibraryModel"
                    );
                    var filePaths = uploadResults
                        .Select(uploadResult => uploadResult["FilesFullPath"].ToString())
                        .ToList();
                    libraryModelDtoForUpdate.File = filePaths[0];
                }
                var user = await _manager.LibraryModelService.UpdateLibraryModelAsync(
                    libraryModelDtoForUpdate.ID,
                    libraryModelDtoForUpdate,
                    false
                );
                return Ok(ApiResponse<LibraryModelDto>.Success(user, Messages.Success.Updated));
            }
            catch (System.Exception)
            {
                return BadRequest(ApiResponse<LibraryModelDto>.Error(Messages.Error.NotFound));
            }
        }

        [HttpDelete("Delete/{id:int}")]
        [AuthorizePermission("LibraryModel", "Delete")]
        public async Task<IActionResult> DeleteOneLibraryModelAsync([FromRoute] int id)
        {
            try
            {
                var user = await _manager.LibraryModelService.DeleteLibraryModelAsync(id, false);
                return Ok(ApiResponse<LibraryModelDto>.Success(user, Messages.Success.Deleted));
            }
            catch (System.Exception)
            {
                return BadRequest(ApiResponse<LibraryModelDto>.Error(Messages.Error.NotFound));
            }
        }
    }
}
