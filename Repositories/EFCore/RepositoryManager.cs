using Repositories.Contracts;

namespace Repositories.EFCore
{
    public class RepositoryManager : IRepositoryManager
    {
        private readonly RepositoryContext _context;
        private readonly IBlogRepository _blogRepository;
        private readonly IFormRepository _formRepository;
        private readonly IFormElementRepository _formElementRepository;
        private readonly IFormResponseRepository _formResponseRepository;
        private readonly IGalleryRepository _galleryRepository;
        private readonly ILanguageRepository _languageRepository;
        private readonly ILibraryModelRepository _libraryModelRepository;
        private readonly ILogRepository _logRepository;
        private readonly IModuleRepository _moduleRepository;
        private readonly IModuleContentRepository _moduleContentRepository;
        private readonly IModuleFieldRepository _moduleFieldRepository;
        private readonly IServicesRepository _servicesRepository;
        private readonly IUserRepository _userRepository;
        private readonly IUserPermissionRepository _userPermissionRepository;

        public RepositoryManager(
            RepositoryContext context,
            IBlogRepository blogRepository,
            IFormRepository formRepository,
            IFormElementRepository formElementRepository,
            IFormResponseRepository formResponseRepository,
            IGalleryRepository galleryRepository,
            ILanguageRepository languageRepository,
            ILibraryModelRepository libraryModelRepository,
            ILogRepository logRepository,
            IModuleRepository moduleRepository,
            IModuleContentRepository moduleContentRepository,
            IModuleFieldRepository moduleFieldRepository,
            IServicesRepository servicesRepository,
            IUserRepository userRepository,
            IUserPermissionRepository userPermissionRepository
        )
        {
            _context = context;
            _blogRepository = blogRepository;
            _formRepository = formRepository;
            _formElementRepository = formElementRepository;
            _formResponseRepository = formResponseRepository;
            _galleryRepository = galleryRepository;
            _languageRepository = languageRepository;
            _libraryModelRepository = libraryModelRepository;
            _logRepository = logRepository;
            _moduleRepository = moduleRepository;
            _moduleContentRepository = moduleContentRepository;
            _moduleFieldRepository = moduleFieldRepository;
            _servicesRepository = servicesRepository;
            _userRepository = userRepository;
            _userPermissionRepository = userPermissionRepository;
        }

        public IBlogRepository BlogRepository => _blogRepository;
        public IFormRepository FormRepository => _formRepository;
        public IFormElementRepository FormElementRepository => _formElementRepository;
        public IFormResponseRepository FormResponseRepository => _formResponseRepository;
        public IGalleryRepository GalleryRepository => _galleryRepository;
        public ILanguageRepository LanguageRepository => _languageRepository;
        public ILibraryModelRepository LibraryModelRepository => _libraryModelRepository;
        public ILogRepository LogRepository => _logRepository;
        public IModuleRepository ModuleRepository => _moduleRepository;
        public IModuleContentRepository ModuleContentRepository => _moduleContentRepository;
        public IModuleFieldRepository ModuleFieldRepository => _moduleFieldRepository;
        public IServicesRepository ServicesRepository => _servicesRepository;
        public IUserRepository UserRepository => _userRepository;
        public IUserPermissionRepository UserPermissionRepository => _userPermissionRepository;

        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
