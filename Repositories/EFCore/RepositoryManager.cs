using Repositories.Contracts;

namespace Repositories.EFCore
{
    public class RepositoryManager : IRepositoryManager
    {
        private readonly RepositoryContext _context;
        private readonly IBlogRepository _blogRepository;
        private readonly ILogRepository _logRepository;
        private readonly IServicesRepository _servicesRepository;
        private readonly IUserRepository _userRepository;
        private readonly IUserPermissionRepository _userPermissionRepository;

        public RepositoryManager(
            RepositoryContext context,
            IBlogRepository blogRepository,
            ILogRepository logRepository,
            IServicesRepository servicesRepository,
            IUserRepository userRepository,
            IUserPermissionRepository userPermissionRepository
        )
        {
            _context = context;
            _blogRepository = blogRepository;
            _logRepository = logRepository;
            _servicesRepository = servicesRepository;
            _userRepository = userRepository;
            _userPermissionRepository = userPermissionRepository;
        }

        public IBlogRepository BlogRepository => _blogRepository;
        public ILogRepository LogRepository => _logRepository;
        public IServicesRepository ServicesRepository => _servicesRepository;
        public IUserRepository UserRepository => _userRepository;
        public IUserPermissionRepository UserPermissionRepository => _userPermissionRepository;

        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
