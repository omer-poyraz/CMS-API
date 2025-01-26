using Services.Contracts;

namespace Services
{
    public class ServiceManager : IServiceManager
    {
        private readonly IAuthenticationService _authenticationService;
        private readonly IUserService _userService;
        private readonly IUserPermissionService _userPermissionService;
        private readonly IServicesService _servicesService;

        public ServiceManager(
            IAuthenticationService authenticationService,
            IUserService userService,
            IUserPermissionService userPermissionService,
            IServicesService servicesService
        )
        {
            _authenticationService = authenticationService;
            _userService = userService;
            _userPermissionService = userPermissionService;
            _servicesService = servicesService;
        }

        public IAuthenticationService AuthenticationService => _authenticationService;
        public IUserService UserService => _userService;
        public IUserPermissionService UserPermissionService => _userPermissionService;
        public IServicesService ServicesService => _servicesService;
    }
}
