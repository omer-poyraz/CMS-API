using AutoMapper;
using Entities.DTOs.UserPermissionDto;
using Entities.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Repositories.Contracts;
using Repositories.EFCore;
using Services.Contracts;

namespace Services
{
    public class UserPermissionService : IUserPermissionService
    {
        private readonly UserManager<User> _userManager;
        private readonly IRepositoryManager _manager;
        private readonly RepositoryContext _context;
        private readonly IMapper _mapper;

        public UserPermissionService(
            UserManager<User> userManager,
            IRepositoryManager manager,
            IMapper mapper,
            RepositoryContext context
        )
        {
            _userManager = userManager;
            _manager = manager;
            _mapper = mapper;
            _context = context;
        }

        public async Task<UserPermissionDto> CreateUserPermissionAsync(
            UserPermissionDtoForInsertion userPermissionGroupDtoForInsertion
        )
        {
            var userPermissionGroup = _mapper.Map<UserPermission>(
                userPermissionGroupDtoForInsertion
            );
            _manager.UserPermissionRepository.CreateUserPermission(userPermissionGroup);
            await _manager.SaveAsync();
            return _mapper.Map<UserPermissionDto>(userPermissionGroup);
        }

        public async Task<UserPermissionDto> DeleteUserPermissionAsync(int id, bool trackChanges)
        {
            var userPermissionGroup =
                await _manager.UserPermissionRepository.GetUserPermissionByIdAsync(
                    id,
                    trackChanges
                );
            _manager.UserPermissionRepository.DeleteUserPermission(userPermissionGroup);
            await _manager.SaveAsync();
            return _mapper.Map<UserPermissionDto>(userPermissionGroup);
        }

        public async Task<IEnumerable<UserPermissionDto>> GetAllUserPermissionsAsync(
            bool trackChanges
        )
        {
            var userPermissionGroup =
                await _manager.UserPermissionRepository.GetAllUserPermissionsAsync(trackChanges);
            return _mapper.Map<IEnumerable<UserPermissionDto>>(userPermissionGroup);
        }

        public async Task<IEnumerable<UserPermissionDto>> GetUserPermissionsByUserIdAsync(
            string userId,
            bool trackChanges
        )
        {
            var userPermissionGroup =
                await _manager.UserPermissionRepository.GetUserPermissionsByUserIdAsync(
                    userId,
                    trackChanges
                );
            return _mapper.Map<IEnumerable<UserPermissionDto>>(userPermissionGroup);
        }

        public async Task<UserPermissionDto> GetUserPermissionByIdAsync(int id, bool trackChanges)
        {
            var userPermissionGroup =
                await _manager.UserPermissionRepository.GetUserPermissionByIdAsync(
                    id,
                    trackChanges
                );
            return _mapper.Map<UserPermissionDto>(userPermissionGroup);
        }

        public async Task<UserPermissionDto> UpdateUserPermissionAsync(
            int id,
            UserPermissionDtoForUpdate userPermissionGroupDtoForUpdate,
            bool trackChanges
        )
        {
            var userPermissionGroup =
                await _manager.UserPermissionRepository.GetUserPermissionByIdAsync(
                    id,
                    trackChanges
                );
            userPermissionGroup = _mapper.Map<UserPermission>(userPermissionGroupDtoForUpdate);
            _manager.UserPermissionRepository.UpdateUserPermission(userPermissionGroup);
            await _manager.SaveAsync();
            return _mapper.Map<UserPermissionDto>(userPermissionGroup);
        }

        public async Task<bool> HasPermissionAsync(
            string userId,
            string serviceName,
            string permissionType
        )
        {
            var permissions = await _context
                .UserPermissions.Where(up => up.userId == userId && up.service_name == serviceName)
                .FirstOrDefaultAsync();

            if (permissions == null)
            {
                return false;
            }

            return permissionType switch
            {
                "SuperAdmin" => permissions.can_super_admin,
                "Read" => permissions.can_read,
                "Write" => permissions.can_write,
                "Delete" => permissions.can_delete,
                "Btk" => permissions.can_btk,
                "Ethernet" => permissions.can_ethernet,
                "Consumer" => permissions.can_consumer,
                "Hosting" => permissions.can_hosting,
                _ => false,
            };
        }
    }
}
