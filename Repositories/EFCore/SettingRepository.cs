using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Repositories.Contracts;

namespace Repositories.EFCore
{
    public class SettingRepository : RepositoryBase<Setting>, ISettingRepository
    {
        public SettingRepository(RepositoryContext context) : base(context)
        {
        }

        public Setting CreateSetting(Setting setting)
        {
            Create(setting);
            return setting;
        }

        public Setting DeleteSetting(Setting setting)
        {
            Delete(setting);
            return setting;
        }

        public async Task<IEnumerable<Setting>> GetAllSettingsAsync(bool trackChanges) => await FindAll(trackChanges)
            .OrderBy(s => s.SettingID)
            .Include(s => s.User)
            .Include(s => s.HomeSeo)
            .Include(s => s.ContactSeo)
            .Include(s => s.SocialMediaDark)
                .ThenInclude(s => s.Socials)
            .Include(s => s.SocialMediaWhite)
                .ThenInclude(s => s.Socials)
            .ToListAsync();

        public async Task<Setting> GetSettingByIdAsync(int id, bool trackChanges) => await FindByCondition(s => s.SettingID.Equals(id), trackChanges)
            .Include(s => s.User)
            .Include(s => s.HomeSeo)
            .Include(s => s.ContactSeo)
            .Include(s => s.SocialMediaDark)
                .ThenInclude(s => s.Socials)
            .Include(s => s.SocialMediaWhite)
                .ThenInclude(s => s.Socials)
            .SingleOrDefaultAsync();

        public Setting UpdateSetting(Setting setting)
        {
            Update(setting);
            return setting;
        }
    }
}
