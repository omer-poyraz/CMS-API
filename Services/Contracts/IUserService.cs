using Entities.DTOs.UserDto;
using Entities.RequestFeature;
using Entities.RequestFeature.User;

namespace Services.Contracts
{
    public interface IUserService
    {
        Task<(IEnumerable<UserDto> userDtos, MetaData metaData)> GetAllUsersAsync(UserParameters userParameters, bool trackChanges);
        Task<UserDto> GetOneUserByIdAsync(string? userId, bool trackChanges);
        Task<UserDto> UpdateOneUserAsync(string? userId, UserDtoForUpdate userDtoForUpdate, bool trackChanges);
        Task<UserDto> ChangePasswordAsync(string? userId, string currentPassword, string newPassword, bool trackChanges);
        Task<UserDto> DeleteOneUserAsync(string? userId, bool trackChanges);
    }
}
