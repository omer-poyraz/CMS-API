using Repositories.Contracts;

namespace Repositories.EFCore
{
    public class RepositoryManager : IRepositoryManager
    {
        private readonly RepositoryContext _context;
        private readonly IUserRepository _userRepository;
        private readonly IUserPermissionRepository _userPermissionRepository;
        private readonly IServicesRepository _servicesRepository;

        public RepositoryManager(
            IUserRepository userRepository,
            RepositoryContext context,
            IUserPermissionRepository userPermissionRepository,
            IServicesRepository servicesRepository
        )
        {
            _context = context;
            _userRepository = userRepository;
            _userPermissionRepository = userPermissionRepository;
            _servicesRepository = servicesRepository;
        }

        public IUserRepository UserRepository => _userRepository;
        public IUserPermissionRepository UserPermissionRepository => _userPermissionRepository;
        public IServicesRepository ServicesRepository => _servicesRepository;

        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
