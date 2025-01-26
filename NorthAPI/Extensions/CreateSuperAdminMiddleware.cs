using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Entities.DTOs.UserDto;
using Entities.DTOs.UserPermissionDto;
using Entities.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using Services.Contracts;

public class CreateSuperAdminMiddleware
{
    private readonly RequestDelegate _next;

    public CreateSuperAdminMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        context.Items["CreateSuperAdminMiddlewareRunning"] = true;

        var authService = context.RequestServices.GetRequiredService<IAuthenticationService>();
        var userManager = context.RequestServices.GetRequiredService<UserManager<User>>();
        var userPermissionService =
            context.RequestServices.GetRequiredService<IUserPermissionService>();

        var superAdminExists = await userManager.GetUsersInRoleAsync("Super Admin");
        if (superAdminExists.Any())
        {
            await _next(context);
            return;
        }

        var superAdminBody = new
        {
            FirstName = "Ömer",
            LastName = "Poyraz",
            UserName = "omer-poyraz",
            Email = "omerr.poyrazz@gmail.com",
            PhoneNumber = "05303561831",
            Password = "Omer_4812",
            Gender = "Erkek",
            Company = "Liberyus",
            Phone2 = "05303561831",
            Fax = "05303561831",
            Address = "Ayyıldız Mahallesi Mimar Sinan Sokak 13/16 Pursaklar/ANKARA",
            Roles = new[] { "Super Admin" },
        };

        var jsonBody = JsonConvert.SerializeObject(superAdminBody);
        var bodyStream = new MemoryStream(System.Text.Encoding.UTF8.GetBytes(jsonBody));
        context.Request.Body = bodyStream;
        context.Request.ContentLength = jsonBody.Length;
        context.Request.ContentType = "application/json";

        try
        {
            var registerDto = JsonConvert.DeserializeObject<UserForRegisterDto>(jsonBody);
            var result = await authService.RegisterUser(registerDto);

            if (!result.Succeeded)
            {
                context.Response.StatusCode = StatusCodes.Status400BadRequest;
                await context.Response.WriteAsync("Failed to create SuperAdmin.");
                return;
            }
        }
        catch (Exception ex)
        {
            context.Response.StatusCode = StatusCodes.Status500InternalServerError;
            await context.Response.WriteAsync($"Error creating SuperAdmin: {ex.Message}");
            return;
        }

        await _next(context);
    }
}
