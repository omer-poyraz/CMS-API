using Services.Contracts;

namespace Services
{
    public class ServiceManager : IServiceManager
    {
        private readonly IAuthenticationService _authenticationService;
        private readonly IUserService _userService;
        private readonly IUserPermissionService _userPermissionService;
        private readonly IServicesService _servicesService;
        private readonly ILogService _logService;

        public ServiceManager(
            IAuthenticationService authenticationService,
            IUserService userService,
            IUserPermissionService userPermissionService,
            IServicesService servicesService,
            ILogService logService
        )
        {
            _authenticationService = authenticationService;
            _userService = userService;
            _userPermissionService = userPermissionService;
            _servicesService = servicesService;
            _logService = logService;
        }

        public IAuthenticationService AuthenticationService => _authenticationService;
        public IUserService UserService => _userService;
        public IUserPermissionService UserPermissionService => _userPermissionService;
        public IServicesService ServicesService => _servicesService;
        public ILogService LogService => _logService;
    }
}
