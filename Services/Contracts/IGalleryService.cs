using Entities.DTOs.GalleryDto;

namespace Services.Contracts
{
    public interface IGalleryService
    {
        Task<IEnumerable<GalleryDto>> GetAllGalleriesAsync(bool trackChanges);
        Task<GalleryDto> GetGalleryByIdAsync(int id, bool trackChanges);
        Task<GalleryDto> GetGalleryBySlugAsync(string slug, bool trackChanges);
        Task<GalleryDto> CreateGalleryAsync(GalleryDtoForInsertion galleryDtoForInsertion);
        Task<GalleryDto> UpdateGalleryAsync(
            int id,
            GalleryDtoForUpdate galleryDtoForUpdate,
            bool trackChanges
        );
        Task<GalleryDto> DeleteGalleryAsync(int id, bool trackChanges);
    }
}
