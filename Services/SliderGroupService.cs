using AutoMapper;
using Entities.DTOs.SliderGroupDto;
using Entities.Models;
using Repositories.Contracts;
using Services.Contracts;

namespace Services
{
    public class SliderGroupService : ISliderGroupService
    {
        private readonly IRepositoryManager _manager;
        private readonly IMapper _mapper;
        public SliderGroupService(IRepositoryManager manager, IMapper mapper)
        {
            _manager = manager;
            _mapper = mapper;
        }

        public async Task<SliderGroupDto> CreateSliderGroupAsync(SliderGroupDtoForInsertion sliderGroupDtoForInsertion)
        {
            var sliderGroup = _mapper.Map<SliderGroup>(sliderGroupDtoForInsertion);
            _manager.SliderGroupRepository.CreateSliderGroup(sliderGroup);
            await _manager.SaveAsync();
            return _mapper.Map<SliderGroupDto>(sliderGroup);
        }

        public async Task<SliderGroupDto> DeleteSliderGroupAsync(int id, bool trackChanges)
        {
            var sliderGroup = await _manager.SliderGroupRepository.GetSliderGroupByIdAsync(id, trackChanges);
            _manager.SliderGroupRepository.DeleteSliderGroup(sliderGroup);
            await _manager.SaveAsync();
            return _mapper.Map<SliderGroupDto>(sliderGroup);
        }

        public async Task<IEnumerable<SliderGroupDto>> GetAllSliderGroupsAsync(bool trackChanges)
        {
            var sliderGroup = await _manager.SliderGroupRepository.GetAllSliderGroupsAsync(trackChanges);
            return _mapper.Map<IEnumerable<SliderGroupDto>>(sliderGroup);
        }

        public async Task<SliderGroupDto> GetSliderGroupByIdAsync(int id, bool trackChanges)
        {
            var sliderGroup = await _manager.SliderGroupRepository.GetSliderGroupByIdAsync(id, trackChanges);
            return _mapper.Map<SliderGroupDto>(sliderGroup);
        }

        public async Task<SliderGroupDto> UpdateSliderGroupAsync(int id, SliderGroupDtoForUpdate sliderGroupDtoForUpdate, bool trackChanges)
        {
            var sliderGroup = await _manager.SliderGroupRepository.GetSliderGroupByIdAsync(id, trackChanges);
            sliderGroup = _mapper.Map<SliderGroup>(sliderGroupDtoForUpdate);
            _manager.SliderGroupRepository.UpdateSliderGroup(sliderGroup);
            await _manager.SaveAsync();
            return _mapper.Map<SliderGroupDto>(sliderGroup);
        }
    }
}
