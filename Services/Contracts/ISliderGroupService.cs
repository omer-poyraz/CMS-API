using Entities.DTOs.SliderGroupDto;

namespace Services.Contracts
{
    public interface ISliderGroupService
    {
        Task<IEnumerable<SliderGroupDto>> GetAllSliderGroupsAsync(bool trackChanges);
        Task<SliderGroupDto> GetSliderGroupByIdAsync(int id, bool trackChanges);
        Task<SliderGroupDto> CreateSliderGroupAsync(SliderGroupDtoForInsertion sliderGroupDtoForInsertion);
        Task<SliderGroupDto> UpdateSliderGroupAsync(int id, SliderGroupDtoForUpdate sliderGroupDtoForUpdate, bool trackChanges);
        Task<SliderGroupDto> DeleteSliderGroupAsync(int id, bool trackChanges);
    }
}
