using AutoMapper;
using Entities.DTOs.BlogDto;
using Entities.DTOs.FormDto;
using Entities.DTOs.FormElementDto;
using Entities.DTOs.FormResponseDto;
using Entities.DTOs.GalleryDto;
using Entities.DTOs.LanguageDto;
using Entities.DTOs.LibraryModelDto;
using Entities.DTOs.LogDto;
using Entities.DTOs.ModuleContentDto;
using Entities.DTOs.ModuleDto;
using Entities.DTOs.ModuleFieldDto;
using Entities.DTOs.ServicesDto;
using Entities.DTOs.SettingsDto;
using Entities.DTOs.UserDto;
using Entities.DTOs.UserPermissionDto;
using Entities.Models;
using Microsoft.AspNetCore.Identity;

namespace NorthAPI.Utilities.AutoMapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<BlogDtoForUpdate, Blog>().ReverseMap();
            CreateMap<Blog, BlogDto>();
            CreateMap<BlogDtoForInsertion, Blog>();

            CreateMap<FormDtoForUpdate, Form>().ReverseMap();
            CreateMap<Form, FormDto>();
            CreateMap<FormDtoForInsertion, Form>();

            CreateMap<FormElementDtoForUpdate, FormElement>().ReverseMap();
            CreateMap<FormElement, FormElementDto>();
            CreateMap<FormElementDtoForInsertion, FormElement>();

            CreateMap<FormResponseDtoForUpdate, FormResponse>().ReverseMap();
            CreateMap<FormResponse, FormResponseDto>();
            CreateMap<FormResponseDtoForInsertion, FormResponse>();

            CreateMap<GalleryDtoForUpdate, Gallery>().ReverseMap();
            CreateMap<Gallery, GalleryDto>();
            CreateMap<GalleryDtoForInsertion, Gallery>();

            CreateMap<LanguageDtoForUpdate, Language>().ReverseMap();
            CreateMap<Language, LanguageDto>();
            CreateMap<LanguageDtoForInsertion, Language>();

            CreateMap<LibraryModelDtoForUpdate, LibraryModel>().ReverseMap();
            CreateMap<LibraryModel, LibraryModelDto>();
            CreateMap<LibraryModelDtoForInsertion, LibraryModel>();

            CreateMap<Log, LogDto>();
            CreateMap<LogDtoForInsertion, Log>();

            CreateMap<ModuleDtoForUpdate, Module>().ReverseMap();
            CreateMap<Module, ModuleDto>();
            CreateMap<ModuleDtoForInsertion, Module>();

            CreateMap<ModuleContentDtoForUpdate, ModuleContent>().ReverseMap();
            CreateMap<ModuleContent, ModuleContentDto>();
            CreateMap<ModuleContentDtoForInsertion, ModuleContent>();

            CreateMap<ModuleFieldDtoForUpdate, ModuleField>().ReverseMap();
            CreateMap<ModuleField, ModuleFieldDto>();
            CreateMap<ModuleFieldDtoForInsertion, ModuleField>();

            CreateMap<ServicesDtoForUpdate, Entities.Models.Services>().ReverseMap();
            CreateMap<Entities.Models.Services, ServicesDto>();
            CreateMap<ServicesDtoForInsertion, Entities.Models.Services>();

            CreateMap<SettingsDtoForUpdate, Settings>().ReverseMap();
            CreateMap<Settings, SettingsDto>();
            CreateMap<SettingsDtoForInsertion, Settings>();

            CreateMap<UserForRegisterDto, User>();
            CreateMap<UserDtoForUpdate, User>().ReverseMap();
            CreateMap<User, UserDto>();
            CreateMap<IdentityResult, UserDto>().ReverseMap();

            CreateMap<UserPermissionDtoForUpdate, UserPermission>().ReverseMap();
            CreateMap<UserPermission, UserPermissionDto>();
            CreateMap<UserPermissionDtoForInsertion, UserPermission>();
        }
    }
}
