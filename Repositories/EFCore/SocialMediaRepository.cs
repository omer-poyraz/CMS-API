using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Repositories.Contracts;

namespace Repositories.EFCore
{
    public class SocialMediaRepository : RepositoryBase<SocialMedia>, ISocialMediaRepository
    {
        public SocialMediaRepository(RepositoryContext context) : base(context)
        {
        }

        public SocialMedia CreateSocialMedia(SocialMedia socialMedia)
        {
            Create(socialMedia);
            return socialMedia;
        }

        public SocialMedia DeleteSocialMedia(SocialMedia socialMedia)
        {
            Delete(socialMedia);
            return socialMedia;
        }

        public async Task<IEnumerable<SocialMedia>> GetAllSocialMediasAsync(bool trackChanges) => await FindAll(trackChanges)
            .OrderBy(s=>s.SocialMediaID)
            .Include(s=>s.User)
            .Include(s=>s.Socials)
            .ToListAsync();

        public async Task<SocialMedia> GetSocialMediaByIdAsync(int id, bool trackChanges) => await FindByCondition(s => s.SocialMediaID.Equals(id), trackChanges)
            .Include(s=>s.User)
            .Include(s=>s.Socials)
            .SingleOrDefaultAsync();

        public SocialMedia UpdateSocialMedia(SocialMedia socialMedia)
        {
            Update(socialMedia);
            return socialMedia;
        }
    }
}
