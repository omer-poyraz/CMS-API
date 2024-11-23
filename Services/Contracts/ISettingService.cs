using Entities.DTOs.SettingDto;

namespace Services.Contracts
{
    public interface ISettingService
    {
        Task<IEnumerable<SettingDto>> GetAllSettingsAsync(bool trackChanges);
        Task<SettingDto> GetSettingByIdAsync(int id, bool trackChanges);
        Task<SettingDto> CreateSettingAsync(SettingDtoForInsertion settingDtoForInsertion);
        Task<SettingDto> UpdateSettingAsync(int id, SettingDtoForUpdate settingDtoForUpdate, bool trackChanges);
        Task<SettingDto> DeleteSettingAsync(int id, bool trackChanges);
    }
}
