using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Repositories.Contracts;

namespace Repositories.EFCore
{
    public class SocialRepository : RepositoryBase<Social>, ISocialRepository
    {
        public SocialRepository(RepositoryContext context) : base(context)
        {
        }

        public Social CreateSocial(Social social)
        {
            Create(social);
            return social;
        }

        public Social DeleteSocial(Social social)
        {
            Delete(social);
            return social;
        }

        public async Task<IEnumerable<Social>> GetAllSocialsAsync(bool trackChanges) => await FindAll(trackChanges)
            .OrderBy(s=>s.SocialID)
            .Include(s=>s.User)
            .Include(s=>s.SocialMedia)
            .ToListAsync();

        public async Task<IEnumerable<Social>> GetAllSocialsBySocialAsync(int id, bool trackChanges) => await FindAll(trackChanges)
            .Where(s=>s.SocialMediaID==id)
            .OrderBy(s=>s.SocialID)
            .Include(s=>s.User)
            .Include(s=>s.SocialMedia)
            .ToListAsync();

        public async Task<Social> GetSocialByIdAsync(int id, bool trackChanges) => await FindByCondition(s => s.SocialID.Equals(id), trackChanges)
            .Include(s=>s.User)
            .Include(s=>s.SocialMedia)
            .SingleOrDefaultAsync();

        public Social UpdateSocial(Social social)
        {
            Update(social);
            return social;
        }
    }
}
