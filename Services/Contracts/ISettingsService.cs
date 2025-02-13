using Entities.DTOs.SettingsDto;

namespace Services.Contracts
{
    public interface ISettingsService
    {
        Task<IEnumerable<SettingsDto>> GetAllSettingsAsync(bool trackChanges);
        Task<SettingsDto> GetSettingsByIdAsync(int id, bool trackChanges);
        Task<SettingsDto> GetSettingsBySiteAsync(string site, bool trackChanges);
        Task<SettingsDto> CreateSettingsAsync(SettingsDtoForInsertion settingsDtoForInsertion);
        Task<SettingsDto> UpdateSettingsAsync(int id, SettingsDtoForUpdate settingsDtoForUpdate, bool trackChanges);
        Task<SettingsDto> DeleteSettingsAsync(int id, bool trackChanges);
    }
}
