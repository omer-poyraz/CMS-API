using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Repositories.Contracts;

namespace Repositories.EFCore
{
    public class GalleryRepository : RepositoryBase<Gallery>, IGalleryRepository
    {
        public GalleryRepository(RepositoryContext context)
            : base(context) { }

        public Gallery CreateGallery(Gallery gallery)
        {
            Create(gallery);
            return gallery;
        }

        public Gallery DeleteGallery(Gallery gallery)
        {
            Delete(gallery);
            return gallery;
        }

        public async Task<IEnumerable<Gallery>> GetAllGalleriesAsync(bool trackChanges) =>
            await FindAll(trackChanges).OrderBy(s => s.ID).Include(s => s.User).ToListAsync();

        public async Task<Gallery> GetGalleryByIdAsync(int id, bool trackChanges) =>
            await FindByCondition(s => s.ID.Equals(id), trackChanges)
                .Include(s => s.User)
                .SingleOrDefaultAsync();

        public async Task<Gallery> GetGalleryBySlugAsync(string slug, bool trackChanges) =>
            await FindByCondition(s => s.Slug.Equals(slug) || s.SlugEN.Equals(slug), trackChanges)
                .Include(s => s.User)
                .SingleOrDefaultAsync();

        public Gallery UpdateGallery(Gallery gallery)
        {
            Update(gallery);
            return gallery;
        }
    }
}
