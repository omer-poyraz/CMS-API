using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Repositories.Contracts;

namespace Repositories.EFCore
{
    public class ImageGroupRepository : RepositoryBase<ImageGroup>, IImageGroupRepository
    {
        public ImageGroupRepository(RepositoryContext context)
            : base(context) { }

        public async Task<ImageGroup> CreateImageGroup(ImageGroup imageGroup)
        {
            var imageGroups = await FindAll(false).ToListAsync();
            imageGroup.Sort = imageGroups.Count() + 1;
            Create(imageGroup);
            return imageGroup;
        }

        public ImageGroup DeleteImageGroup(ImageGroup imageGroup)
        {
            Delete(imageGroup);
            return imageGroup;
        }

        public async Task<ImageGroup> SortImageGroupAsync(int id, int newSort, bool trackChanges)
        {
            var imageGroup = await FindByCondition(h => h.ImageGroupID == id, trackChanges)
                .SingleOrDefaultAsync();
            var imageGroup2 = await FindByCondition(h => h.Sort == newSort, trackChanges)
                .SingleOrDefaultAsync();
            if (imageGroup2 != null)
            {
                imageGroup2.Sort = imageGroup.Sort;
                Update(imageGroup2);
            }
            imageGroup.Sort = newSort;
            Update(imageGroup);
            return imageGroup;
        }

        public async Task<IEnumerable<ImageGroup>> GetAllImageGroupsAsync(bool trackChanges) =>
            await FindAll(trackChanges)
                .OrderBy(s => s.ImageGroupID)
                .Include(s => s.Images)
                .Include(s => s.User)
                .ToListAsync();

        public async Task<ImageGroup> GetImageGroupByIdAsync(int id, bool trackChanges) =>
            await FindByCondition(s => s.ImageGroupID.Equals(id), trackChanges)
                .Include(s => s.Images)
                .Include(s => s.User)
                .SingleOrDefaultAsync();

        public ImageGroup UpdateImageGroup(ImageGroup imageGroup)
        {
            Update(imageGroup);
            return imageGroup;
        }
    }
}
