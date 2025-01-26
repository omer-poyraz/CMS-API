using Entities.Models;

namespace Repositories.Contracts
{
    public interface IUserPermissionRepository : IRepositoryBase<UserPermission>
    {
        Task<IEnumerable<UserPermission>> GetAllUserPermissionsAsync(bool trackChanges);
        Task<UserPermission> GetUserPermissionByIdAsync(int id, bool trackChanges);
        Task<IEnumerable<UserPermission>> GetUserPermissionsByUserIdAsync(
            string userId,
            bool trackChanges
        );
        UserPermission CreateUserPermission(UserPermission userPermission);
        UserPermission UpdateUserPermission(UserPermission userPermission);
        UserPermission DeleteUserPermission(UserPermission userPermission);
    }
}
