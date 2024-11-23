using Entities.Models;

namespace Repositories.Contracts
{
    public interface ISliderGroupRepository : IRepositoryBase<SliderGroup>
    {
        Task<IEnumerable<SliderGroup>> GetAllSliderGroupsAsync(bool trackChanges);
        Task<SliderGroup> GetSliderGroupByIdAsync(int id, bool trackChanges);
        SliderGroup CreateSliderGroup(SliderGroup sliderGroup);
        SliderGroup UpdateSliderGroup(SliderGroup sliderGroup);
        SliderGroup DeleteSliderGroup(SliderGroup sliderGroup);
    }
}
