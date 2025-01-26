using Microsoft.Extensions.FileProviders;
using NorthAPI.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddHttpClient();

builder
    .Services.AddControllers(opt =>
    {
        opt.RespectBrowserAcceptHeader = true;
        opt.ReturnHttpNotAcceptable = true;
    })
    .AddApplicationPart(typeof(Presentation.AssemblyReference).Assembly)
    .AddNewtonsoftJson(opt =>
        opt.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
    );

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.ConfigureSqlContext(builder.Configuration);
builder.Services.ConfigureGeneral();
builder.Services.ConfigureIdentity();
builder.Services.AddHttpContextAccessor();
builder.Services.ConfigureJwt(builder.Configuration);
builder.Services.ConfigureSwagger();
builder.Services.AddAutoMapper(typeof(Program));

var app = builder.Build();

app.UseDeveloperExceptionPage();
app.UseSwagger();
app.UseSwaggerUI();

app.UseMiddleware<CreateSuperAdminMiddleware>();

app.UseHttpsRedirection();
app.UsePathBase("/api");

app.UseAuthentication();
app.UseAuthorization();

app.UseStaticFiles();
app.UseStaticFiles(
    new StaticFileOptions
    {
        FileProvider = new PhysicalFileProvider(
            Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images")
        ),
        RequestPath = "/images",
    }
);

app.UseCors("CorsPolicy");

app.MapControllers();

app.Run();
