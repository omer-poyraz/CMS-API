﻿using System.Text;
using Entities.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Repositories.Contracts;
using Repositories.EFCore;
using Services;
using Services.Contracts;
using Services.Extensions;

namespace NorthAPI.Extensions
{
    public static class ServiceExtensions
    {
        public static void ConfigureSqlContext(
            this IServiceCollection services,
            IConfiguration configuration
        ) =>
            services.AddDbContext<RepositoryContext>(opt =>
                opt.UseNpgsql(configuration.GetConnectionString("sqlConnection"))
            );

        public static void ConfigureGeneral(this IServiceCollection services)
        {
            services.AddScoped<IRepositoryManager, RepositoryManager>();
            services.AddScoped<IServiceManager, ServiceManager>();

            services.AddSingleton(new FileReaderService());
            services.AddScoped<IAuthenticationService, AuthenticationService>();

            services.AddScoped<IBlogRepository, BlogRepository>();
            services.AddScoped<IBlogService, BlogService>();

            services.AddScoped<IFormRepository, FormRepository>();
            services.AddScoped<IFormService, FormService>();

            services.AddScoped<IFormElementRepository, FormElementRepository>();
            services.AddScoped<IFormElementService, FormElementService>();

            services.AddScoped<IFormResponseRepository, FormResponseRepository>();
            services.AddScoped<IFormResponseService, FormResponseService>();

            services.AddScoped<IGalleryRepository, GalleryRepository>();
            services.AddScoped<IGalleryService, GalleryService>();

            services.AddScoped<ILanguageRepository, LanguageRepository>();
            services.AddScoped<ILanguageService, LanguageService>();

            services.AddScoped<ILibraryModelRepository, LibraryModelRepository>();
            services.AddScoped<ILibraryModelService, LibraryModelService>();

            services.AddScoped<ILogRepository, LogRepository>();
            services.AddScoped<ILogService, LogService>();

            services.AddScoped<IModuleRepository, ModuleRepository>();
            services.AddScoped<IModuleService, ModuleService>();

            services.AddScoped<IModuleContentRepository, ModuleContentRepository>();
            services.AddScoped<IModuleContentService, ModuleContentService>();

            services.AddScoped<IModuleFieldRepository, ModuleFieldRepository>();
            services.AddScoped<IModuleFieldService, ModuleFieldService>();

            services.AddScoped<IServicesRepository, ServicesRepository>();
            services.AddScoped<IServicesService, ServicesService>();

            services.AddScoped<ISettingsRepository, SettingsRepository>();
            services.AddScoped<ISettingsService, SettingsService>();

            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IUserService, UserService>();

            services.AddScoped<IUserPermissionRepository, UserPermissionRepository>();
            services.AddScoped<IUserPermissionService, UserPermissionService>();

            services.AddCors(opt =>
            {
                opt.AddPolicy(
                    "CorsPolicy",
                    build =>
                        build
                            .AllowAnyHeader()
                            .AllowAnyOrigin()
                            .AllowAnyMethod()
                            .WithExposedHeaders("X-Pagination")
                );
            });
        }

        public static void ConfigureIdentity(this IServiceCollection services)
        {
            var builder = services
                .AddIdentity<User, IdentityRole>(opt =>
                {
                    opt.Password.RequireLowercase = false;
                    opt.Password.RequireDigit = true;
                    opt.Password.RequireUppercase = false;
                    opt.Password.RequireNonAlphanumeric = false;
                    opt.Password.RequiredLength = 6;

                    opt.User.RequireUniqueEmail = true;
                })
                .AddEntityFrameworkStores<RepositoryContext>()
                .AddDefaultTokenProviders();
        }

        public static void ConfigureJwt(
            this IServiceCollection services,
            IConfiguration configuration
        )
        {
            var jwtSettings = configuration.GetSection("JwtSettings");
            var secretKey = jwtSettings["secretKey"];

            services
                .AddAuthentication(opt =>
                {
                    opt.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                    opt.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                })
                .AddJwtBearer(opt =>
                {
                    opt.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = true,
                        ValidateAudience = true,
                        ValidateLifetime = true,
                        ValidateIssuerSigningKey = true,
                        ValidIssuer = jwtSettings["validIssuer"],
                        ValidAudience = jwtSettings["validAudience"],
                        IssuerSigningKey = new SymmetricSecurityKey(
                            Encoding.UTF8.GetBytes(secretKey!)
                        ),
                    };
                });
        }

        public static void ConfigureSwagger(this IServiceCollection services)
        {
            services.AddSwaggerGen(s =>
            {
                s.SwaggerDoc("v1", new OpenApiInfo { Title = "CMS API", Version = "v1" });
                s.AddSecurityDefinition(
                    "Bearer",
                    new OpenApiSecurityScheme()
                    {
                        In = ParameterLocation.Header,
                        Description = "Bearer xxTOKENxx",
                        Name = "Authorization",
                        Type = SecuritySchemeType.ApiKey,
                        Scheme = "Bearer",
                    }
                );

                s.AddSecurityRequirement(
                    new OpenApiSecurityRequirement()
                    {
                        {
                            new OpenApiSecurityScheme
                            {
                                Reference = new OpenApiReference
                                {
                                    Type = ReferenceType.SecurityScheme,
                                    Id = "Bearer",
                                },
                                Name = "Bearer",
                            },
                            new List<string>()
                        },
                    }
                );
            });
        }
    }
}
