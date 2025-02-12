using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Repositories.Contracts;

namespace Repositories.EFCore
{
    public class LanguageRepository : RepositoryBase<Language>, ILanguageRepository
    {
        public LanguageRepository(RepositoryContext context)
            : base(context) { }

        public Language CreateLanguage(Language language)
        {
            Create(language);
            return language;
        }

        public Language DeleteLanguage(Language language)
        {
            Delete(language);
            return language;
        }

        public async Task<IEnumerable<Language>> GetAllLanguagesAsync(bool trackChanges) =>
            await FindAll(trackChanges).OrderBy(s => s.ID).Include(s => s.User).ToListAsync();

        public async Task<Language> GetLanguageByIdAsync(int id, bool trackChanges) =>
            await FindByCondition(s => s.ID.Equals(id), trackChanges)
                .Include(s => s.User)
                .SingleOrDefaultAsync();

        public Language UpdateLanguage(Language language)
        {
            Update(language);
            return language;
        }
    }
}
