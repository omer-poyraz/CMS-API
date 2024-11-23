using Entities.Models;

namespace Repositories.Contracts
{
    public interface ISettingRepository : IRepositoryBase<Setting>
    {
        Task<IEnumerable<Setting>> GetAllSettingsAsync(bool trackChanges);
        Task<Setting> GetSettingByIdAsync(int id, bool trackChanges);
        Setting CreateSetting(Setting setting);
        Setting UpdateSetting(Setting setting);
        Setting DeleteSetting(Setting setting);
    }
}
