using Entities.Models;

namespace Repositories.Contracts
{
    public interface IImageRepository : IRepositoryBase<Image>
    {
        Task<IEnumerable<Image>> GetAllImagesAsync(bool trackchanges);
        Task<Image> GetImageByIdAsync(int id, bool trackchanges);
        Task<Image> SortImageAsync(int id, int newSort, bool trackchanges);
        Task<Image> CreateImage(Image image);
        Image UpdateImage(Image image);
        Image DeleteImage(Image image);
    }
}
