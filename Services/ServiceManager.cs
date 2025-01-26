using Services.Contracts;

namespace Services
{
    public class ServiceManager : IServiceManager
    {
        private readonly IAuthenticationService _authenticationService;
        private readonly IUserService _userService;
        private readonly IUserPermissionService _userPermissionService;

        public ServiceManager(
            IAuthenticationService authenticationService,
            IUserService userService,
            IUserPermissionService userPermissionService
        )
        {
            _authenticationService = authenticationService;
            _userService = userService;
            _userPermissionService = userPermissionService;
        }

        public IAuthenticationService AuthenticationService => _authenticationService;
        public IUserService UserService => _userService;
        public IUserPermissionService UserPermissionService => _userPermissionService;
    }
}
