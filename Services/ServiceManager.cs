using Services.Contracts;

namespace Services
{
    public class ServiceManager : IServiceManager
    {
        private readonly IAuthenticationService _authenticationService;
        private readonly IUserService _userService;
        private readonly ILogService _logService;
        private readonly IFormService _formService;
        private readonly IDealerService _dealerService;
        private readonly IContactService _contactService;
        private readonly ISocialService _socialService;
        private readonly ISocialMediaService _socialMediaService;
        private readonly IHeaderService _headerService;
        private readonly ISettingService _settingService;
        private readonly ISliderService _sliderService;
        private readonly ISliderGroupService _sliderGroupService;
        private readonly IProductService _productService;
        private readonly IProductGroupService _productGroupService;
        private readonly ISeoService _seoService;
        private readonly IDocumentService _documentService;
        private readonly IDocumentGroupService _documentGroupService;
        private readonly IPageService _pageService;
        private readonly IImageService _imageService;
        private readonly IImageGroupService _imageGroupService;

        public ServiceManager(
            IAuthenticationService authenticationService,
            IUserService userService,
            ILogService logService,
            IHeaderService headerService,
            ISettingService settingService,
            IContactService contactService,
            IFormService formService,
            IDealerService dealerService,
            ISocialService socialService,
            ISocialMediaService socialMediaService,
            ISliderService sliderService,
            ISliderGroupService sliderGroupService,
            IProductService productService,
            IProductGroupService productGroupService,
            ISeoService seoService,
            IDocumentService documentService,
            IDocumentGroupService documentGroupService,
            IPageService pageService,
            IImageService imageService,
            IImageGroupService imageGroupService
        )
        {
            _authenticationService = authenticationService;
            _userService = userService;
            _logService = logService;
            _formService = formService;
            _dealerService = dealerService;
            _contactService = contactService;
            _socialService = socialService;
            _socialMediaService = socialMediaService;
            _headerService = headerService;
            _settingService = settingService;
            _sliderService = sliderService;
            _sliderGroupService = sliderGroupService;
            _productService = productService;
            _productGroupService = productGroupService;
            _seoService = seoService;
            _documentService = documentService;
            _documentGroupService = documentGroupService;
            _pageService = pageService;
            _imageService = imageService;
            _imageGroupService = imageGroupService;
        }

        public IAuthenticationService AuthenticationService => _authenticationService;
        public IUserService UserService => _userService;
        public ILogService LogService => _logService;
        public IFormService FormService => _formService;
        public IDealerService DealerService => _dealerService;
        public IContactService ContactService => _contactService;
        public ISocialService SocialService => _socialService;
        public ISocialMediaService SocialMediaService => _socialMediaService;
        public IHeaderService HeaderService => _headerService;
        public ISettingService SettingService => _settingService;
        public ISliderService SliderService => _sliderService;
        public ISliderGroupService SliderGroupService => _sliderGroupService;
        public IProductService ProductService => _productService;
        public IProductGroupService ProductGroupService => _productGroupService;
        public ISeoService SeoService => _seoService;
        public IDocumentService DocumentService => _documentService;
        public IDocumentGroupService DocumentGroupService => _documentGroupService;
        public IPageService PageService => _pageService;
        public IImageService ImageService => _imageService;
        public IImageGroupService ImageGroupService => _imageGroupService;
    }
}
