using Entities.DTOs.ImageDto;

namespace Services.Contracts
{
    public interface IImageService
    {
        Task<IEnumerable<ImageDto>> GetAllImagesAsync(bool trackChanges);
        Task<ImageDto> GetImageByIdAsync(int id, bool trackChanges);
        Task<ImageDto> SortImageAsync(int id, int newSort, bool trackChanges);
        Task<ImageDto> CreateImageAsync(ImageDtoForInsertion imageDtoForInsertion);
        Task<ImageDto> UpdateImageAsync(int id, ImageDtoForUpdate imageDtoForUpdate, bool trackChanges);
        Task<ImageDto> DeleteImageAsync(int id, bool trackChanges);
    }
}
