using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Repositories.Contracts;

namespace Repositories.EFCore
{
    public class UserPermissionRepository
        : RepositoryBase<UserPermission>,
            IUserPermissionRepository
    {
        public UserPermissionRepository(RepositoryContext context)
            : base(context) { }

        public UserPermission CreateUserPermission(UserPermission userPermission)
        {
            Create(userPermission);
            return userPermission;
        }

        public UserPermission DeleteUserPermission(UserPermission userPermission)
        {
            Delete(userPermission);
            return userPermission;
        }

        public async Task<IEnumerable<UserPermission>> GetAllUserPermissionsAsync(
            bool trackChanges
        ) => await FindAll(trackChanges).OrderBy(s => s.ID).Include(s => s.User).ToListAsync();

        public async Task<IEnumerable<UserPermission>> GetUserPermissionsByUserIdAsync(
            string userId,
            bool trackChanges
        ) =>
            await FindAll(trackChanges)
                .Where(s => s.UserId == userId)
                .OrderBy(s => s.ID)
                .Include(s => s.User)
                .ToListAsync();

        public async Task<UserPermission> GetUserPermissionByIdAsync(int id, bool trackChanges) =>
            await FindByCondition(s => s.ID.Equals(id), trackChanges)
                .Include(s => s.User)
                .SingleOrDefaultAsync();

        public UserPermission UpdateUserPermission(UserPermission userPermission)
        {
            Update(userPermission);
            return userPermission;
        }
    }
}
