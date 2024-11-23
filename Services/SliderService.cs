using AutoMapper;
using Entities.DTOs.SliderDto;
using Entities.Models;
using Repositories.Contracts;
using Services.Contracts;

namespace Services
{
    public class SliderService : ISliderService
    {
        private readonly IRepositoryManager _manager;
        private readonly IMapper _mapper;
        public SliderService(IRepositoryManager manager, IMapper mapper)
        {
            _manager = manager;
            _mapper = mapper;
        }

        public async Task<SliderDto> CreateSliderAsync(SliderDtoForInsertion sliderDtoForInsertion)
        {
            var slider = _mapper.Map<Slider>(sliderDtoForInsertion);
            _manager.SliderRepository.CreateSlider(slider);
            await _manager.SaveAsync();
            return _mapper.Map<SliderDto>(slider);
        }

        public async Task<SliderDto> DeleteSliderAsync(int id, bool trackChanges)
        {
            var slider = await _manager.SliderRepository.GetSliderByIdAsync(id, trackChanges);
            _manager.SliderRepository.DeleteSlider(slider);
            await _manager.SaveAsync();
            return _mapper.Map<SliderDto>(slider);
        }

        public async Task<IEnumerable<SliderDto>> GetAllSlidersAsync(bool trackChanges)
        {
            var slider = await _manager.SliderRepository.GetAllSlidersAsync(trackChanges);
            return _mapper.Map<IEnumerable<SliderDto>>(slider);
        }

        public async Task<IEnumerable<SliderDto>> GetAllSlidersByGroupAsync(int id, bool trackChanges)
        {
            var slider = await _manager.SliderRepository.GetAllSlidersByGroupAsync(id, trackChanges);
            return _mapper.Map<IEnumerable<SliderDto>>(slider);
        }

        public async Task<SliderDto> GetSliderByIdAsync(int id, bool trackChanges)
        {
            var slider = await _manager.SliderRepository.GetSliderByIdAsync(id, trackChanges);
            return _mapper.Map<SliderDto>(slider);
        }

        public async Task<SliderDto> UpdateSliderAsync(int id, SliderDtoForUpdate sliderDtoForUpdate, bool trackChanges)
        {
            var slider = await _manager.SliderRepository.GetSliderByIdAsync(id, trackChanges);
            slider = _mapper.Map<Slider>(sliderDtoForUpdate);
            _manager.SliderRepository.UpdateSlider(slider);
            await _manager.SaveAsync();
            return _mapper.Map<SliderDto>(slider);
        }
    }
}
