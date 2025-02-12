using Entities.Models;

namespace Repositories.Contracts
{
    public interface IGalleryRepository : IRepositoryBase<Gallery>
    {
        Task<IEnumerable<Gallery>> GetAllGalleriesAsync(bool trackChanges);
        Task<Gallery> GetGalleryByIdAsync(int id, bool trackChanges);
        Task<Gallery> GetGalleryBySlugAsync(string slug, bool trackChanges);
        Gallery CreateGallery(Gallery gallery);
        Gallery UpdateGallery(Gallery gallery);
        Gallery DeleteGallery(Gallery gallery);
    }
}
