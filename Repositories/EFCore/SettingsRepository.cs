using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Repositories.Contracts;

namespace Repositories.EFCore
{
    public class SettingsRepository : RepositoryBase<Settings>, ISettingsRepository
    {
        public SettingsRepository(RepositoryContext context)
            : base(context) { }

        public Settings CreateSettings(Settings settings)
        {
            Create(settings);
            return settings;
        }

        public Settings DeleteSettings(Settings settings)
        {
            Delete(settings);
            return settings;
        }

        public async Task<IEnumerable<Settings>> GetAllSettingsAsync(bool trackChanges) =>
            await FindAll(trackChanges).OrderBy(s => s.ID).Include(s => s.User).ToListAsync();

        public async Task<Settings> GetSettingsByIdAsync(int id, bool trackChanges) =>
            await FindByCondition(s => s.ID.Equals(id), trackChanges)
                .Include(s => s.User)
                .Include(s => s.Module)
                .SingleOrDefaultAsync();

        public async Task<Settings> GetSettingsBySiteAsync(string site, bool trackChanges) =>
            await FindByCondition(s => s.Site.Equals(site), trackChanges)
                .Include(s => s.User)
                .Include(s => s.Module)
                .SingleOrDefaultAsync();

        public Settings UpdateSettings(Settings settings)
        {
            Update(settings);
            return settings;
        }
    }
}
