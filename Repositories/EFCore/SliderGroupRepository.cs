using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Repositories.Contracts;

namespace Repositories.EFCore
{
    public class SliderGroupRepository : RepositoryBase<SliderGroup>, ISliderGroupRepository
    {
        public SliderGroupRepository(RepositoryContext context) : base(context)
        {
        }

        public SliderGroup CreateSliderGroup(SliderGroup sliderGroup)
        {
            Create(sliderGroup);
            return sliderGroup;
        }

        public SliderGroup DeleteSliderGroup(SliderGroup sliderGroup)
        {
            Delete(sliderGroup);
            return sliderGroup;
        }

        public async Task<IEnumerable<SliderGroup>> GetAllSliderGroupsAsync(bool trackChanges) => await FindAll(trackChanges)
            .OrderBy(s=>s.SliderGroupID)
            .Include(s=>s.User)
            .Include(s=>s.Sliders)
            .ToListAsync();

        public async Task<SliderGroup> GetSliderGroupByIdAsync(int id, bool trackChanges) => await FindByCondition(s => s.SliderGroupID.Equals(id), trackChanges)
            .Include(s=>s.User)
            .Include(s=>s.Sliders)
            .SingleOrDefaultAsync();

        public SliderGroup UpdateSliderGroup(SliderGroup sliderGroup)
        {
            Update(sliderGroup);
            return sliderGroup;
        }
    }
}
