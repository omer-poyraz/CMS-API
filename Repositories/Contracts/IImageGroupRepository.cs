using Entities.Models;

namespace Repositories.Contracts
{
    public interface IImageGroupRepository : IRepositoryBase<ImageGroup>
    {
        Task<IEnumerable<ImageGroup>> GetAllImageGroupsAsync(bool trackChanges);
        Task<ImageGroup> GetImageGroupByIdAsync(int id, bool trackChanges);
        Task<ImageGroup> SortImageGroupAsync(int id, int newSort, bool trackChanges);
        Task<ImageGroup> CreateImageGroup(ImageGroup imageGroup);
        ImageGroup UpdateImageGroup(ImageGroup imageGroup);
        ImageGroup DeleteImageGroup(ImageGroup imageGroup);
    }
}
