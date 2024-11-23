using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Repositories.Contracts;

namespace Repositories.EFCore
{
    public class ImageRepository : RepositoryBase<Image>, IImageRepository
    {
        public ImageRepository(RepositoryContext context)
            : base(context) { }

        public async Task<Image> CreateImage(Image image)
        {
            var images = await FindAll(false).ToListAsync();
            image.Sort = images.Count() + 1;
            Create(image);
            return image;
        }

        public Image DeleteImage(Image image)
        {
            Delete(image);
            return image;
        }

        public async Task<Image> SortImageAsync(int id, int newSort, bool trackChanges)
        {
            var image = await FindByCondition(h => h.ImageID == id, trackChanges)
                .SingleOrDefaultAsync();
            var image2 = await FindByCondition(h => h.Sort == newSort, trackChanges)
                .SingleOrDefaultAsync();
            if (image2 != null)
            {
                image2.Sort = image.Sort;
                Update(image2);
            }
            image.Sort = newSort;
            Update(image);
            return image;
        }

        public async Task<IEnumerable<Image>> GetAllImagesAsync(bool trackChanges) =>
            await FindAll(trackChanges)
                .OrderBy(s => s.ImageID)
                .Include(s => s.User)
                .ToListAsync();

        public async Task<Image> GetImageByIdAsync(int id, bool trackChanges) =>
            await FindByCondition(s => s.ImageID.Equals(id), trackChanges)
                .Include(s => s.User)
                .SingleOrDefaultAsync();

        public Image UpdateImage(Image image)
        {
            Update(image);
            return image;
        }
    }
}
