using AutoMapper;
using Entities.DTOs.ImageGroupDto;
using Entities.Models;
using Repositories.Contracts;
using Services.Contracts;

namespace Services
{
    public class ImageGroupService : IImageGroupService
    {
        private readonly IRepositoryManager _manager;
        private readonly IMapper _mapper;
        public ImageGroupService(IRepositoryManager manager, IMapper mapper)
        {
            _manager = manager;
            _mapper = mapper;
        }

        public async Task<ImageGroupDto> CreateImageGroupAsync(ImageGroupDtoForInsertion imageGroupDtoForInsertion)
        {
            var imageGroup = _mapper.Map<ImageGroup>(imageGroupDtoForInsertion);
            _manager.ImageGroupRepository.CreateImageGroup(imageGroup);
            await _manager.SaveAsync();
            return _mapper.Map<ImageGroupDto>(imageGroup);
        }

        public async Task<ImageGroupDto> DeleteImageGroupAsync(int id, bool trackChanges)
        {
            var imageGroup = await _manager.ImageGroupRepository.GetImageGroupByIdAsync(id, trackChanges);
            _manager.ImageGroupRepository.DeleteImageGroup(imageGroup);
            await _manager.SaveAsync();
            return _mapper.Map<ImageGroupDto>(imageGroup);
        }

        public async Task<IEnumerable<ImageGroupDto>> GetAllImageGroupsAsync(bool trackChanges)
        {
            var imageGroup = await _manager.ImageGroupRepository.GetAllImageGroupsAsync(trackChanges);
            return _mapper.Map<IEnumerable<ImageGroupDto>>(imageGroup);
        }

        public async Task<ImageGroupDto> GetImageGroupByIdAsync(int id, bool trackChanges)
        {
            var imageGroup = await _manager.ImageGroupRepository.GetImageGroupByIdAsync(id, trackChanges);
            return _mapper.Map<ImageGroupDto>(imageGroup);
        }

        public async Task<ImageGroupDto> SortImageGroupAsync(int id, int newSort, bool trackChanges)
        {
            var imageGroup = await _manager.ImageGroupRepository.SortImageGroupAsync(id, newSort, trackChanges);
            return _mapper.Map<ImageGroupDto>(imageGroup);
        }

        public async Task<ImageGroupDto> UpdateImageGroupAsync(int id, ImageGroupDtoForUpdate imageGroupDtoForUpdate, bool trackChanges)
        {
            var imageGroup = await _manager.ImageGroupRepository.GetImageGroupByIdAsync(id, trackChanges);
            imageGroup = _mapper.Map<ImageGroup>(imageGroupDtoForUpdate);
            _manager.ImageGroupRepository.UpdateImageGroup(imageGroup);
            await _manager.SaveAsync();
            return _mapper.Map<ImageGroupDto>(imageGroup);
        }
    }
}
