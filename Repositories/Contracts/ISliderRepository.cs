using Entities.Models;

namespace Repositories.Contracts
{
    public interface ISliderRepository : IRepositoryBase<Slider>
    {
        Task<IEnumerable<Slider>> GetAllSlidersAsync(bool trackChanges);
        Task<IEnumerable<Slider>> GetAllSlidersByGroupAsync(int id, bool trackChanges);
        Task<Slider> GetSliderByIdAsync(int id, bool trackChanges);
        Slider CreateSlider(Slider slider);
        Slider UpdateSlider(Slider slider);
        Slider DeleteSlider(Slider slider);
    }
}
