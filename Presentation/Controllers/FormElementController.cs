// using System.Text.Json;
// using Entities.DTOs.FormElementDto;
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
//     [Route("api/FormElement")]
//     public class FormElementController : ControllerBase
//     {
//         private readonly IServiceManager _manager;

//         public FormElementController(IServiceManager manager)
//         {
//             _manager = manager;
//         }

//         [HttpGet("GetAll")]
//         // [AuthorizePermission("FormElement", "Read")]
//         public async Task<IActionResult> GetAllFormElementsAsync()
//         {
//             try
//             {
//                 var users = await _manager.FormElementService.GetAllFormElementsAsync(false);
//                 return Ok(
//                     ApiResponse<IEnumerable<FormElementDto>>.Success(users, Messages.Success.Listed)
//                 );
//             }
//             catch (Exception ex)
//             {
//                 return BadRequest(
//                     ApiResponse<IEnumerable<FormElementDto>>.Error(Messages.Error.ServerError)
//                 );
//             }
//         }

//         [HttpGet("Get/{id:int}")]
//         // [AuthorizePermission("FormElement", "Read")]
//         public async Task<IActionResult> GetOneFormElementByIdAsync([FromRoute] int id)
//         {
//             try
//             {
//                 var user = await _manager.FormElementService.GetFormElementByIdAsync(id, false);
//                 return Ok(ApiResponse<FormElementDto>.Success(user, Messages.Success.Retrieved));
//             }
//             catch (System.Exception)
//             {
//                 return BadRequest(ApiResponse<FormElementDto>.Error(Messages.Error.NotFound));
//             }
//         }

//         [HttpPost("Create")]
//         [AuthorizePermission("FormElement", "Write")]
//         public async Task<IActionResult> CreateOneFormElementAsync(
//             ICollection<IFormFile>? file,
//             [FromForm] FormElementDtoForInsertion formElementDtoForInsertion
//         )
//         {
//             try
//             {
//                 var rnd = new Random();
//                 var imgId = rnd.Next(0, 100000);
//                 if (file != null)
//                 {
//                     var uploadResults = await FileManager.FileUpload(file, imgId, "FormElement");
//                     var filePaths = uploadResults
//                         .Select(uploadResult => uploadResult["FilesFullPath"].ToString())
//                         .ToList();
//                     formElementDtoForInsertion.files = filePaths;
//                 }
//                 var user = await _manager.FormElementService.CreateFormElementAsync(
//                     formElementDtoForInsertion
//                 );
//                 return Ok(ApiResponse<FormElementDto>.Success(user, Messages.Success.Created));
//             }
//             catch (System.Exception)
//             {
//                 return BadRequest(ApiResponse<FormElementDto>.Error(Messages.Error.NotFound));
//             }
//         }

//         [HttpPut("Update")]
//         // [AuthorizePermission("FormElement", "Write")]
//         public async Task<IActionResult> UpdateOneUserAsync(
//             ICollection<IFormFile>? file,
//             [FromForm] FormElementDtoForUpdate formElementDtoForUpdate
//         )
//         {
//             try
//             {
//                 var rnd = new Random();
//                 var imgId = rnd.Next(0, 100000);
//                 if (file.Count() > 0)
//                 {
//                     var uploadResults = await FileManager.FileUpload(file, imgId, "FormElement");
//                     var filePaths = uploadResults
//                         .Select(uploadResult => uploadResult["FilesFullPath"].ToString())
//                         .ToList();
//                     formElementDtoForUpdate.files = filePaths;
//                 }
//                 var user = await _manager.FormElementService.UpdateFormElementAsync(
//                     formElementDtoForUpdate.ID,
//                     formElementDtoForUpdate,
//                     false
//                 );
//                 return Ok(ApiResponse<FormElementDto>.Success(user, Messages.Success.Updated));
//             }
//             catch (System.Exception)
//             {
//                 return BadRequest(ApiResponse<FormElementDto>.Error(Messages.Error.NotFound));
//             }
//         }

//         [HttpDelete("Delete/{id:int}")]
//         [AuthorizePermission("FormElement", "Delete")]
//         public async Task<IActionResult> DeleteOneFormElementAsync([FromRoute] int id)
//         {
//             try
//             {
//                 var user = await _manager.FormElementService.DeleteFormElementAsync(id, false);
//                 return Ok(ApiResponse<FormElementDto>.Success(user, Messages.Success.Deleted));
//             }
//             catch (System.Exception)
//             {
//                 return BadRequest(ApiResponse<FormElementDto>.Error(Messages.Error.NotFound));
//             }
//         }
//     }
// }
