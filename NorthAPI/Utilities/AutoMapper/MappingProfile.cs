using AutoMapper;
using Entities.DTOs.UserDto;
using Entities.DTOs.UserPermissionDto;
using Entities.Models;
using Microsoft.AspNetCore.Identity;
using Newtonsoft.Json;

namespace NorthAPI.Utilities.AutoMapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
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
