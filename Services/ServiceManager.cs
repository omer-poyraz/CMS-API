using Services.Contracts;

namespace Services
{
    public class ServiceManager : IServiceManager
    {
        private readonly IAuthenticationService _authenticationService;
        private readonly IBlogService _blogService;
        private readonly ILogService _logService;
        private readonly IServicesService _servicesService;
        private readonly IUserService _userService;
        private readonly IUserPermissionService _userPermissionService;

        public ServiceManager(
            IAuthenticationService authenticationService,
            IBlogService blogService,
            ILogService logService,
            IServicesService servicesService,
            IUserService userService,
            IUserPermissionService userPermissionService
        )
        {
            _authenticationService = authenticationService;
            _blogService = blogService;
            _logService = logService;
            _servicesService = servicesService;
            _userService = userService;
            _userPermissionService = userPermissionService;
        }

        public IAuthenticationService AuthenticationService => _authenticationService;
        public IBlogService BlogService => _blogService;
        public ILogService LogService => _logService;
        public IServicesService ServicesService => _servicesService;
        public IUserService UserService => _userService;
        public IUserPermissionService UserPermissionService => _userPermissionService;
    }
}
