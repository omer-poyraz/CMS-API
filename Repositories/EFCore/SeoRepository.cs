using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Repositories.Contracts;

namespace Repositories.EFCore
{
    public class SeoRepository : RepositoryBase<Seo>, ISeoRepository
    {
        public SeoRepository(RepositoryContext context) : base(context)
        {
        }

        public Seo CreateSeo(Seo seo)
        {
            Create(seo);
            return seo;
        }

        public Seo DeleteSeo(Seo seo)
        {
            Delete(seo);
            return seo;
        }

        public async Task<IEnumerable<Seo>> GetAllSeosAsync(bool trackChanges) => await FindAll(trackChanges)
            .OrderBy(s=>s.SeoID)
            .Include(s=>s.User)
            .ToListAsync();

        public async Task<Seo> GetSeoByIdAsync(int id, bool trackChanges) => await FindByCondition(s => s.SeoID.Equals(id), trackChanges)
            .Include(s=>s.User)
            .SingleOrDefaultAsync();

        public Seo UpdateSeo(Seo seo)
        {
            Update(seo);
            return seo;
        }
    }
}
