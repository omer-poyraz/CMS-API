using Entities.DTOs.UserPermissionDto;

namespace Services.Contracts
{
    public interface IUserPermissionService
    {
        Task<IEnumerable<UserPermissionDto>> GetAllUserPermissionsAsync(bool trackChanges);
        Task<UserPermissionDto> GetUserPermissionByIdAsync(int id, bool trackChanges);
        Task<bool> HasPermissionAsync(string userId, string serviceName, string permissionType);
        Task<UserPermissionDto> CreateUserPermissionAsync(
            UserPermissionDtoForInsertion userPermissionDtoForInsertion
        );
        Task<UserPermissionDto> UpdateUserPermissionAsync(
            int id,
            UserPermissionDtoForUpdate userPermissionDtoForUpdate,
            bool trackChanges
        );
        Task<IEnumerable<UserPermissionDto>> GetUserPermissionsByUserIdAsync(
            string userId,
            bool trackChanges
        );
        Task<UserPermissionDto> DeleteUserPermissionAsync(int id, bool trackChanges);
    }
}
