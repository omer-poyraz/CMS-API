using Entities.DTOs.UserDto;
using Entities.Response;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Services.Contracts;
using Services.ResultModels.Requests;

namespace Presentation.Controllers
{
    [ApiController]
    [Route("api/Authentication")]
    public class AuthenticationController : ControllerBase
    {
        private readonly IServiceManager _manager;

        public AuthenticationController(IServiceManager manager)
        {
            _manager = manager;
        }

        [HttpPost("Login")]
        public async Task<IActionResult> Login(
            [FromBody] UserForAuthenticationDto userForAuthenticationDto
        )
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(
                        ApiResponse<TokenDto>.Error(Messages.Error.ValidationError, 400)
                    );

                if (!await _manager.AuthenticationService.ValidUser(userForAuthenticationDto))
                    return Unauthorized(
                        ApiResponse<TokenDto>.Error(Messages.Error.InvalidCredentials, 401)
                    );

                var token = await _manager.AuthenticationService.CreateToken(true);
                return Ok(ApiResponse<TokenDto>.Success(token, Messages.Success.LoginSuccess));
            }
            catch (Exception ex)
            {
                return StatusCode(500, ApiResponse<TokenDto>.Error(Messages.Error.ServerError));
            }
        }

        [HttpPost("Register")]
        public async Task<IActionResult> Register([FromBody] UserForRegisterDto userForRegisterDto)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(
                        ApiResponse<IdentityResult>.Error(Messages.Error.ValidationError, 400)
                    );

                var result = await _manager.AuthenticationService.RegisterUser(userForRegisterDto);

                if (!result.Succeeded)
                {
                    var errors = result.Errors.Select(e => e.Description).ToList();
                    foreach (var error in result.Errors)
                    {
                        ModelState.TryAddModelError(error.Code, error.Description);
                    }
                    return BadRequest(
                        ApiResponse<List<string>>.Error(Messages.Error.RegisterFailed, 400)
                    );
                }

                return Ok(
                    ApiResponse<IdentityResult>.Success(result, Messages.Success.RegisterSuccess)
                );
            }
            catch (Exception ex)
            {
                return StatusCode(
                    500,
                    ApiResponse<IdentityResult>.Error(Messages.Error.ServerError)
                );
            }
        }

        [HttpPost("Refresh")]
        public async Task<IActionResult> Refresh([FromBody] TokenDto tokenDto)
        {
            try
            {
                var tokenDtoToReturn = await _manager.AuthenticationService.RefreshToken(tokenDto);

                return Ok(
                    ApiResponse<TokenDto>.Success(tokenDtoToReturn, Messages.Success.TokenRefreshed)
                );
            }
            catch (Exception ex)
            {
                return StatusCode(500, ApiResponse<TokenDto>.Error(Messages.Error.ServerError));
            }
        }
    }
}
