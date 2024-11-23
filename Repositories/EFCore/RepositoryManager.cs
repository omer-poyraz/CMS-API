using Repositories.Contracts;

namespace Repositories.EFCore
{
    public class RepositoryManager : IRepositoryManager
    {
        private readonly RepositoryContext _context;
        private readonly IUserRepository _userRepository;
        private readonly IFormRepository _formRepository;
        private readonly IContactRepository _contactRepository;
        private readonly IDealerRepository _dealerRepository;
        private readonly ISocialRepository _socialRepository;
        private readonly ISocialMediaRepository _socialMediaRepository;
        private readonly IHeaderRepository _headerRepository;
        private readonly ISettingRepository _settingRepository;
        private readonly ISliderRepository _sliderRepository;
        private readonly ISliderGroupRepository _sliderGroupRepository;
        private readonly IProductRepository _productRepository;
        private readonly IProductGroupRepository _productGroupRepository;
        private readonly ISeoRepository _seoRepository;
        private readonly IDocumentRepository _documentRepository;
        private readonly IDocumentGroupRepository _documentGroupRepository;
        private readonly IPageRepository _pageRepository;
        private readonly IImageRepository _imageRepository;
        private readonly IImageGroupRepository _imageGroupRepository;

        public RepositoryManager(
            IUserRepository userRepository,
            RepositoryContext context,
            IHeaderRepository headerRepository,
            ISettingRepository settingRepository,
            IContactRepository contactRepository,
            IFormRepository formRepository,
            IDealerRepository dealerRepository,
            ISocialRepository socialRepository,
            ISocialMediaRepository socialMediaRepository,
            ISliderRepository sliderRepository,
            ISliderGroupRepository sliderGroupRepository,
            IProductRepository productRepository,
            IProductGroupRepository productGroupRepository,
            ISeoRepository seoRepository,
            IDocumentRepository documentRepository,
            IDocumentGroupRepository documentGroupRepository,
            IPageRepository pageRepository,
            IImageRepository imageRepository,
            IImageGroupRepository imageGroupRepository
        )
        {
            _context = context;
            _userRepository = userRepository;
            _formRepository = formRepository;
            _dealerRepository = dealerRepository;
            _contactRepository = contactRepository;
            _socialRepository = socialRepository;
            _socialMediaRepository = socialMediaRepository;
            _headerRepository = headerRepository;
            _settingRepository = settingRepository;
            _sliderRepository = sliderRepository;
            _sliderGroupRepository = sliderGroupRepository;
            _productRepository = productRepository;
            _productGroupRepository = productGroupRepository;
            _seoRepository = seoRepository;
            _documentRepository = documentRepository;
            _documentGroupRepository = documentGroupRepository;
            _pageRepository = pageRepository;
            _imageRepository = imageRepository;
        }

        public IUserRepository UserRepository => _userRepository;
        public IFormRepository FormRepository => _formRepository;
        public IDealerRepository DealerRepository => _dealerRepository;
        public IContactRepository ContactRepository => _contactRepository;
        public ISocialRepository SocialRepository => _socialRepository;
        public ISocialMediaRepository SocialMediaRepository => _socialMediaRepository;
        public IHeaderRepository HeaderRepository => _headerRepository;
        public ISettingRepository SettingRepository => _settingRepository;
        public ISliderRepository SliderRepository => _sliderRepository;
        public ISliderGroupRepository SliderGroupRepository => _sliderGroupRepository;
        public IProductRepository ProductRepository => _productRepository;
        public IProductGroupRepository ProductGroupRepository => _productGroupRepository;
        public ISeoRepository SeoRepository => _seoRepository;
        public IDocumentRepository DocumentRepository => _documentRepository;
        public IDocumentGroupRepository DocumentGroupRepository => _documentGroupRepository;
        public IPageRepository PageRepository => _pageRepository;
        public IImageRepository ImageRepository => _imageRepository;
        public IImageGroupRepository ImageGroupRepository => _imageGroupRepository;

        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
