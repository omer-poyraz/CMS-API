// using System.Text.Json;
// using Entities.DTOs.GalleryDto;
// using Entities.RequestFeature.User;
// using Entities.Response;
// using Microsoft.AspNetCore.Authorization;
// using Microsoft.AspNetCore.Http;
// using Microsoft.AspNetCore.Mvc;
// using Services.Contracts;
// using Services.Extensions;
// using Services.ResultModels.Requests;

// namespace Presentation.Controllers
// {
//     [ApiController]
//     [Route("api/Gallery")]
//     public class GalleryController : ControllerBase
//     {
//         private readonly IServiceManager _manager;

//         public GalleryController(IServiceManager manager)
//         {
//             _manager = manager;
//         }

//         [HttpGet("GetAll")]
//         // [AuthorizePermission("Gallery", "Read")]
//         public async Task<IActionResult> GetAllGalleriesAsync()
//         {
//             try
//             {
//                 var users = await _manager.GalleryService.GetAllGalleriesAsync(false);
//                 return Ok(
//                     ApiResponse<IEnumerable<GalleryDto>>.Success(users, Messages.Success.Listed)
//                 );
//             }
//             catch (Exception ex)
//             {
//                 return BadRequest(
//                     ApiResponse<IEnumerable<GalleryDto>>.Error(Messages.Error.ServerError)
//                 );
//             }
//         }

//         [HttpGet("Get/{id:int}")]
//         // [AuthorizePermission("Gallery", "Read")]
//         public async Task<IActionResult> GetOneGalleryByIdAsync([FromRoute] int id)
//         {
//             try
//             {
//                 var user = await _manager.GalleryService.GetGalleryByIdAsync(id, false);
//                 return Ok(ApiResponse<GalleryDto>.Success(user, Messages.Success.Retrieved));
//             }
//             catch (System.Exception)
//             {
//                 return BadRequest(ApiResponse<GalleryDto>.Error(Messages.Error.NotFound));
//             }
//         }

//         [HttpGet("GetSlug/{slug}")]
//         // [AuthorizePermission("Gallery", "Read")]
//         public async Task<IActionResult> GetOneGalleryBySlugAsync([FromRoute] string slug)
//         {
//             try
//             {
//                 var user = await _manager.GalleryService.GetGalleryBySlugAsync(slug, false);
//                 return Ok(ApiResponse<GalleryDto>.Success(user, Messages.Success.Retrieved));
//             }
//             catch (System.Exception)
//             {
//                 return BadRequest(ApiResponse<GalleryDto>.Error(Messages.Error.NotFound));
//             }
//         }

//         [HttpPost("Create")]
//         [AuthorizePermission("Gallery", "Write")]
//         public async Task<IActionResult> CreateOneGalleryAsync(
//             ICollection<IFormFile>? file,
//             [FromForm] GalleryDtoForInsertion galleryDtoForInsertion
//         )
//         {
//             try
//             {
//                 var rnd = new Random();
//                 var imgId = rnd.Next(0, 100000);
//                 if (file != null)
//                 {
//                     var uploadResults = await FileManager.FileUpload(file, imgId, "Gallery");
//                     var filePaths = uploadResults
//                         .Select(uploadResult => uploadResult["FilesFullPath"].ToString())
//                         .ToList();
//                     galleryDtoForInsertion.files = filePaths;
//                 }
//                 var user = await _manager.GalleryService.CreateGalleryAsync(galleryDtoForInsertion);
//                 return Ok(ApiResponse<GalleryDto>.Success(user, Messages.Success.Created));
//             }
//             catch (System.Exception)
//             {
//                 return BadRequest(ApiResponse<GalleryDto>.Error(Messages.Error.NotFound));
//             }
//         }

//         [HttpPut("Update")]
//         // [AuthorizePermission("Gallery", "Write")]
//         public async Task<IActionResult> UpdateOneUserAsync(
//             ICollection<IFormFile>? file,
//             [FromForm] GalleryDtoForUpdate galleryDtoForUpdate
//         )
//         {
//             try
//             {
//                 var rnd = new Random();
//                 var imgId = rnd.Next(0, 100000);
//                 if (file.Count() > 0)
//                 {
//                     var uploadResults = await FileManager.FileUpload(file, imgId, "Gallery");
//                     var filePaths = uploadResults
//                         .Select(uploadResult => uploadResult["FilesFullPath"].ToString())
//                         .ToList();
//                     galleryDtoForUpdate.files = filePaths;
//                 }
//                 var user = await _manager.GalleryService.UpdateGalleryAsync(
//                     galleryDtoForUpdate.ID,
//                     galleryDtoForUpdate,
//                     false
//                 );
//                 return Ok(ApiResponse<GalleryDto>.Success(user, Messages.Success.Updated));
//             }
//             catch (System.Exception)
//             {
//                 return BadRequest(ApiResponse<GalleryDto>.Error(Messages.Error.NotFound));
//             }
//         }

//         [HttpDelete("Delete/{id:int}")]
//         [AuthorizePermission("Gallery", "Delete")]
//         public async Task<IActionResult> DeleteOneGalleryAsync([FromRoute] int id)
//         {
//             try
//             {
//                 var user = await _manager.GalleryService.DeleteGalleryAsync(id, false);
//                 return Ok(ApiResponse<GalleryDto>.Success(user, Messages.Success.Deleted));
//             }
//             catch (System.Exception)
//             {
//                 return BadRequest(ApiResponse<GalleryDto>.Error(Messages.Error.NotFound));
//             }
//         }
//     }
// }
