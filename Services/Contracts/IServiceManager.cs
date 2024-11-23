namespace Services.Contracts
{
    public interface IServiceManager
    {
        IAuthenticationService AuthenticationService { get; }
        IUserService UserService { get; }
        ILogService LogService { get; }
        IFormService FormService { get; }
        IDealerService DealerService { get; }
        IContactService ContactService { get; }
        ISocialService SocialService { get; }
        ISocialMediaService SocialMediaService { get; }
        IHeaderService HeaderService { get; }
        ISettingService SettingService { get; }
        ISliderService SliderService { get; }
        ISliderGroupService SliderGroupService { get; }
        IProductService ProductService { get; }
        IProductGroupService ProductGroupService { get; }
        ISeoService SeoService { get; }
        IDocumentService DocumentService { get; }
        IDocumentGroupService DocumentGroupService { get; }
        IPageService PageService { get; }
        IImageService ImageService { get; }
        IImageGroupService ImageGroupService { get; }
    }
}
