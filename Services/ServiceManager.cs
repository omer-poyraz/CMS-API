using Services.Contracts;

namespace Services
{
    public class ServiceManager : IServiceManager
    {
        private readonly IAuthenticationService _authenticationService;
        private readonly IBlogService _blogService;
        private readonly IFormService _formService;
        private readonly IFormElementService _formElementService;
        private readonly IFormResponseService _formResponseService;
        private readonly IGalleryService _galleryService;
        private readonly ILanguageService _languageService;
        private readonly ILibraryModelService _libraryModelService;
        private readonly ILogService _logService;
        private readonly IModuleService _moduleService;
        private readonly IModuleContentService _moduleContentService;
        private readonly IModuleFieldService _moduleFieldService;
        private readonly IServicesService _servicesService;
        private readonly IUserService _userService;
        private readonly IUserPermissionService _userPermissionService;

        public ServiceManager(
            IAuthenticationService authenticationService,
            IBlogService blogService,
            IFormService formService,
            IFormElementService formElementService,
            IFormResponseService formResponseService,
            IGalleryService galleryService,
            ILanguageService languageService,
            ILibraryModelService libraryModelService,
            ILogService logService,
            IModuleService moduleService,
            IModuleContentService moduleContentService,
            IModuleFieldService moduleFieldService,
            IServicesService servicesService,
            IUserService userService,
            IUserPermissionService userPermissionService
        )
        {
            _authenticationService = authenticationService;
            _blogService = blogService;
            _formService = formService;
            _formElementService = formElementService;
            _formResponseService = formResponseService;
            _galleryService = galleryService;
            _languageService = languageService;
            _libraryModelService = libraryModelService;
            _logService = logService;
            _moduleService = moduleService;
            _moduleContentService = moduleContentService;
            _moduleFieldService = moduleFieldService;
            _servicesService = servicesService;
            _userService = userService;
            _userPermissionService = userPermissionService;
        }

        public IAuthenticationService AuthenticationService => _authenticationService;
        public IBlogService BlogService => _blogService;
        public IFormService FormService => _formService;
        public IFormElementService FormElementService => _formElementService;
        public IFormResponseService FormResponseService => _formResponseService;
        public IGalleryService GalleryService => _galleryService;
        public ILanguageService LanguageService => _languageService;
        public ILibraryModelService LibraryModelService => _libraryModelService;
        public ILogService LogService => _logService;
        public IModuleService ModuleService => _moduleService;
        public IModuleContentService ModuleContentService => _moduleContentService;
        public IModuleFieldService ModuleFieldService => _moduleFieldService;
        public IServicesService ServicesService => _servicesService;
        public IUserService UserService => _userService;
        public IUserPermissionService UserPermissionService => _userPermissionService;
    }
}
