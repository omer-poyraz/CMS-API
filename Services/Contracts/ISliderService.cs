using Entities.DTOs.SliderDto;

namespace Services.Contracts
{
    public interface ISliderService
    {
        Task<IEnumerable<SliderDto>> GetAllSlidersAsync(bool trackChanges);
        Task<IEnumerable<SliderDto>> GetAllSlidersByGroupAsync(int id, bool trackChanges);
        Task<SliderDto> GetSliderByIdAsync(int id, bool trackChanges);
        Task<SliderDto> CreateSliderAsync(SliderDtoForInsertion sliderDtoForInsertion);
        Task<SliderDto> UpdateSliderAsync(int id, SliderDtoForUpdate sliderDtoForUpdate, bool trackChanges);
        Task<SliderDto> DeleteSliderAsync(int id, bool trackChanges);
    }
}
