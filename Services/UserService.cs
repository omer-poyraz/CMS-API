using AutoMapper;
using Entities.DTOs.UserDto;
using Entities.Models;
using Entities.RequestFeature;
using Entities.RequestFeature.User;
using Microsoft.AspNetCore.Identity;
using Repositories.Contracts;
using Services.Contracts;

namespace Services
{
    public class UserService : IUserService
    {
        private readonly IRepositoryManager _manager;
        private readonly IMapper _mapper;
        private UserManager<Entities.Models.User> _userManager;

        public UserService(
            IRepositoryManager manager,
            IMapper mapper,
            UserManager<Entities.Models.User> userManager
        )
        {
            _manager = manager;
            _mapper = mapper;
            _userManager = userManager;
        }

        public async Task<UserDto> DeleteOneUserAsync(string? userId, bool trackChanges)
        {
            var user = await _manager.UserRepository.GetOneUserByIdAsync(userId, trackChanges);
            _manager.UserRepository.DeleteOneUser(user);
            await _manager.SaveAsync();
            return _mapper.Map<UserDto>(user);
        }

        public async Task<(IEnumerable<UserDto> userDtos, MetaData metaData)> GetAllUsersAsync(
            UserParameters userParameters,
            bool trackChanges
        )
        {
            var users = await _manager.UserRepository.GetAllUsersAsync(
                userParameters,
                trackChanges
            );
            var userDto = _mapper.Map<IEnumerable<UserDto>>(users);
            return (userDto, users.MetaData);
        }

        public async Task<UserDto> GetOneUserByIdAsync(string? userId, bool trackChanges)
        {
            var user = await _manager.UserRepository.GetOneUserByIdAsync(userId, trackChanges);
            return _mapper.Map<UserDto>(user);
        }

        public async Task<UserDto> UpdateOneUserAsync(
            string? userId,
            UserDtoForUpdate userDtoForUpdate,
            bool trackChanges
        )
        {
            var userDto = await _manager.UserRepository.GetOneUserByIdAsync(userId, trackChanges);
            var user = await _userManager.FindByEmailAsync(userDto.Email!);

            user!.UserName = userDtoForUpdate.UserName;
            user.FirstName = userDtoForUpdate.FirstName;
            user.LastName = userDtoForUpdate.LastName;
            user.Email = userDtoForUpdate.Email;
            user.PhoneNumber = userDtoForUpdate.PhoneNumber;
            user.Gender = userDtoForUpdate.Gender;
            user.Company = userDtoForUpdate.Company;
            user.Phone2 = userDtoForUpdate.Phone2;
            user.Fax = userDtoForUpdate.Fax;
            user.Address = userDtoForUpdate.Address;
            user.UpdateAt = DateTime.UtcNow;
            await _userManager.UpdateAsync(user);

            return _mapper.Map<UserDto>(user);
        }

        public async Task<UserDto> ChangePasswordAsync(
            string? userId,
            string currentPassword,
            string newPassword,
            bool trackChanges
        )
        {
            var userDto = await _manager.UserRepository.GetOneUserByIdAsync(userId, trackChanges);
            var user = await _userManager.FindByEmailAsync(userDto.Email!);

            await _userManager.ChangePasswordAsync(user!, currentPassword, newPassword);
            return _mapper.Map<UserDto>(user);
        }
    }
}
