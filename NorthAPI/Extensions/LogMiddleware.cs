using System.Security.Claims;
using System.Text;
using System.Text.Json;
using Entities.DTOs.LogDto;
using Entities.Models;
using Microsoft.AspNetCore.Mvc.Controllers;
using Services.Contracts;

namespace NorthAPI.Extensions
{
    public class LogMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<LogMiddleware> _logger;
        private readonly IServiceManager _manager;

        public LogMiddleware(
            RequestDelegate next,
            ILogger<LogMiddleware> logger,
            IServiceManager manager
        )
        {
            _next = next;
            _logger = logger;
            _manager = manager;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            var originalBodyStream = context.Response.Body;

            try
            {
                using var responseBody = new MemoryStream();
                context.Response.Body = responseBody;

                var endpoint = context.GetEndpoint();
                var controllerName = endpoint
                    ?.Metadata.GetMetadata<ControllerActionDescriptor>()
                    ?.ControllerName;
                var actionName = endpoint
                    ?.Metadata.GetMetadata<ControllerActionDescriptor>()
                    ?.ActionName;

                await _next(context);

                responseBody.Seek(0, SeekOrigin.Begin);
                var response = await new StreamReader(responseBody).ReadToEndAsync();
                responseBody.Seek(0, SeekOrigin.Begin);

                var responseObj = JsonSerializer.Deserialize<dynamic>(response);

                var logDto = new LogDtoForInsertion
                {
                    ServiceName = controllerName,
                    StatusCode = context.Response.StatusCode,
                    Message = responseObj?.message?.ToString(),
                    Process = actionName,
                    Result = responseObj?.result?.ToString(),
                    UserId = context.User?.FindFirst(ClaimTypes.NameIdentifier)?.Value,
                    CreatedAt = DateTime.UtcNow,
                };

                await _manager.LogService.CreateLogAsync(logDto);
                await responseBody.CopyToAsync(originalBodyStream);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error in LogMiddleware");
                await _next(context);
            }
            finally
            {
                context.Response.Body = originalBodyStream;
            }
        }
    }

    public static class LogMiddlewareExtensions
    {
        public static IApplicationBuilder UseLogMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<LogMiddleware>();
        }
    }
}
