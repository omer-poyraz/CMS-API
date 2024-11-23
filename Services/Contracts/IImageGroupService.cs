using Entities.DTOs.ImageGroupDto;

namespace Services.Contracts
{
    public interface IImageGroupService
    {
        Task<IEnumerable<ImageGroupDto>> GetAllImageGroupsAsync(bool trackChanges);
        Task<ImageGroupDto> GetImageGroupByIdAsync(int id, bool trackChanges);
        Task<ImageGroupDto> SortImageGroupAsync(int id, int newSort, bool trackChanges);
        Task<ImageGroupDto> CreateImageGroupAsync(ImageGroupDtoForInsertion imageGroupDtoForInsertion);
        Task<ImageGroupDto> UpdateImageGroupAsync(int id, ImageGroupDtoForUpdate imageGroupDtoForUpdate, bool trackChanges);
        Task<ImageGroupDto> DeleteImageGroupAsync(int id, bool trackChanges);
    }
}
