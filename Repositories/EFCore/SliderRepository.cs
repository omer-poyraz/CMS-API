using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Repositories.Contracts;

namespace Repositories.EFCore
{
    public class SliderRepository : RepositoryBase<Slider>, ISliderRepository
    {
        public SliderRepository(RepositoryContext context) : base(context)
        {
        }

        public Slider CreateSlider(Slider slider)
        {
            Create(slider);
            return slider;
        }

        public Slider DeleteSlider(Slider slider)
        {
            Delete(slider);
            return slider;
        }

        public async Task<IEnumerable<Slider>> GetAllSlidersAsync(bool trackChanges) => await FindAll(trackChanges)
            .OrderBy(s=>s.SliderID)
            .Include(s=>s.User)
            .Include(s=>s.SliderGroup)
            .ToListAsync();

        public async Task<IEnumerable<Slider>> GetAllSlidersByGroupAsync(int id, bool trackChanges) => await FindAll(trackChanges)
            .Where(s=>s.SliderGroupID==id)
            .OrderBy(s=>s.SliderID)
            .Include(s=>s.User)
            .Include(s=>s.SliderGroup)
            .ToListAsync();

        public async Task<Slider> GetSliderByIdAsync(int id, bool trackChanges) => await FindByCondition(s => s.SliderID.Equals(id), trackChanges)
            .Include(s=>s.User)
            .Include(s=>s.SliderGroup)
            .SingleOrDefaultAsync();

        public Slider UpdateSlider(Slider slider)
        {
            Update(slider);
            return slider;
        }
    }
}
