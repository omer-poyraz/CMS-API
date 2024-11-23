using AutoMapper;
using Entities.DTOs.SettingDto;
using Entities.Models;
using Repositories.Contracts;
using Services.Contracts;

namespace Services
{
    public class SettingService : ISettingService
    {
        private readonly IRepositoryManager _manager;
        private readonly IMapper _mapper;
        public SettingService(IRepositoryManager manager, IMapper mapper)
        {
            _manager = manager;
            _mapper = mapper;
        }

        public async Task<SettingDto> CreateSettingAsync(SettingDtoForInsertion settingDtoForInsertion)
        {
            var setting = _mapper.Map<Setting>(settingDtoForInsertion);
            _manager.SettingRepository.CreateSetting(setting);
            await _manager.SaveAsync();
            return _mapper.Map<SettingDto>(setting);
        }

        public async Task<SettingDto> DeleteSettingAsync(int id, bool trackChanges)
        {
            var setting = await _manager.SettingRepository.GetSettingByIdAsync(id, trackChanges);
            _manager.SettingRepository.DeleteSetting(setting);
            await _manager.SaveAsync();
            return _mapper.Map<SettingDto>(setting);
        }

        public async Task<IEnumerable<SettingDto>> GetAllSettingsAsync(bool trackChanges)
        {
            var setting = await _manager.SettingRepository.GetAllSettingsAsync(trackChanges);
            return _mapper.Map<IEnumerable<SettingDto>>(setting);
        }

        public async Task<SettingDto> GetSettingByIdAsync(int id, bool trackChanges)
        {
            var setting = await _manager.SettingRepository.GetSettingByIdAsync(id, trackChanges);
            return _mapper.Map<SettingDto>(setting);
        }

        public async Task<SettingDto> UpdateSettingAsync(int id, SettingDtoForUpdate settingDtoForUpdate, bool trackChanges)
        {
            var setting = await _manager.SettingRepository.GetSettingByIdAsync(id, trackChanges);
            _mapper.Map(settingDtoForUpdate, setting);
            _manager.SettingRepository.UpdateSetting(setting);
            await _manager.SaveAsync();
            return _mapper.Map<SettingDto>(setting);
        }
    }
}
