using AutoMapper;
using Entities.DTOs.ImageDto;
using Entities.DTOs.ImageGroupDto;
using Entities.DTOs.UserDto;
using Entities.DTOs.SeoDto;
using Entities.DTOs.FormDto;
using Entities.DTOs.DealerDto;
using Entities.DTOs.ContactDto;
using Entities.DTOs.SocialDto;
using Entities.DTOs.SocialMediaDto;
using Entities.DTOs.HeaderDto;
using Entities.DTOs.SettingDto;
using Entities.DTOs.SliderDto;
using Entities.DTOs.SliderGroupDto;
using Entities.DTOs.ProductDto;
using Entities.DTOs.ProductGroupDto;
using Entities.DTOs.DocumentDto;
using Entities.DTOs.DocumentGroupDto;
using Entities.DTOs.PageDto;
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
            
            CreateMap<FormDtoForUpdate, Form>().ReverseMap();
            CreateMap<Form, FormDto>();
            CreateMap<FormDtoForInsertion, Form>();

            CreateMap<DealerDtoForUpdate, Dealer>().ReverseMap();
            CreateMap<Dealer, DealerDto>();
            CreateMap<DealerDtoForInsertion, Dealer>();

            CreateMap<ContactDtoForUpdate, Contact>().ReverseMap();
            CreateMap<Contact, ContactDto>();
            CreateMap<ContactDtoForInsertion, Contact>();

            CreateMap<SocialDtoForUpdate, Social>().ReverseMap();
            CreateMap<Social, SocialDto>();
            CreateMap<SocialDtoForInsertion, Social>();

            CreateMap<SocialMediaDtoForUpdate, SocialMedia>().ReverseMap();
            CreateMap<SocialMedia, SocialMediaDto>();
            CreateMap<SocialMediaDtoForInsertion, SocialMedia>();

            CreateMap<HeaderDtoForUpdate, Header>().ReverseMap();
            CreateMap<Header, HeaderDto>();
            CreateMap<HeaderDtoForInsertion, Header>();

            CreateMap<SettingDtoForUpdate, Setting>().ReverseMap();
            CreateMap<Setting, SettingDto>();
            CreateMap<SettingDtoForInsertion, Setting>();

            CreateMap<SliderDtoForUpdate, Slider>().ReverseMap();
            CreateMap<Slider, SliderDto>();
            CreateMap<SliderDtoForInsertion, Slider>();

            CreateMap<SliderGroupDtoForUpdate, SliderGroup>().ReverseMap();
            CreateMap<SliderGroup, SliderGroupDto>();
            CreateMap<SliderGroupDtoForInsertion, SliderGroup>();

            CreateMap<ProductDtoForUpdate, Product>().ReverseMap();
            CreateMap<Product, ProductDto>();
            CreateMap<ProductDtoForInsertion, Product>();

            CreateMap<ProductGroupDtoForUpdate, ProductGroup>().ReverseMap();
            CreateMap<ProductGroup, ProductGroupDto>();
            CreateMap<ProductGroupDtoForInsertion, ProductGroup>();

            CreateMap<SeoDtoForUpdate, Seo>().ReverseMap();
            CreateMap<Seo, SeoDto>();
            CreateMap<SeoDtoForInsertion, Seo>();

            CreateMap<DocumentDtoForUpdate, Document>().ReverseMap();
            CreateMap<Document, DocumentDto>();
            CreateMap<DocumentDtoForInsertion, Document>();

            CreateMap<DocumentGroupDtoForUpdate, DocumentGroup>().ReverseMap();
            CreateMap<DocumentGroup, DocumentGroupDto>();
            CreateMap<DocumentGroupDtoForInsertion, DocumentGroup>();

            CreateMap<PageDtoForUpdate, Page>().ReverseMap();
            CreateMap<Page, PageDto>();
            CreateMap<PageDtoForInsertion, Page>();

            CreateMap<ImageDtoForUpdate, Image>().ReverseMap();
            CreateMap<Image, ImageDto>();
            CreateMap<ImageDtoForInsertion, Image>();

            CreateMap<ImageGroupDtoForUpdate, ImageGroup>().ReverseMap();
            CreateMap<ImageGroup, ImageGroupDto>();
            CreateMap<ImageGroupDtoForInsertion, ImageGroup>();
        }
    }
}
