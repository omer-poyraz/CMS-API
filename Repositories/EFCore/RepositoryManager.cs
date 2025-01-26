using Repositories.Contracts;

namespace Repositories.EFCore
{
    public class RepositoryManager : IRepositoryManager
    {
        private readonly RepositoryContext _context;
        private readonly IUserRepository _userRepository;
        private readonly IUserPermissionRepository _userPermissionRepository;

        public RepositoryManager(
            IUserRepository userRepository,
            RepositoryContext context,
            IUserPermissionRepository userPermissionRepository
        )
        {
            _context = context;
            _userRepository = userRepository;
            _userPermissionRepository = userPermissionRepository;
        }

        public IUserRepository UserRepository => _userRepository;
        public IUserPermissionRepository UserPermissionRepository => _userPermissionRepository;

        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
