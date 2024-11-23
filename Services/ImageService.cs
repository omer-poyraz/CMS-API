using AutoMapper;
using Entities.DTOs.ImageDto;
using Entities.Models;
using Repositories.Contracts;
using Services.Contracts;

namespace Services
{
    public class ImageService : IImageService
    {
        private readonly IRepositoryManager _manager;
        private readonly IMapper _mapper;
        public ImageService(IRepositoryManager manager, IMapper mapper)
        {
            _manager = manager;
            _mapper = mapper;
        }

        public async Task<ImageDto> CreateImageAsync(ImageDtoForInsertion imageDtoForInsertion)
        {
            var image = _mapper.Map<Image>(imageDtoForInsertion);
            _manager.ImageRepository.CreateImage(image);
            await _manager.SaveAsync();
            return _mapper.Map<ImageDto>(image);
        }

        public async Task<ImageDto> DeleteImageAsync(int id, bool trackChanges)
        {
            var image = await _manager.ImageRepository.GetImageByIdAsync(id, trackChanges);
            _manager.ImageRepository.DeleteImage(image);
            await _manager.SaveAsync();
            return _mapper.Map<ImageDto>(image);
        }

        public async Task<IEnumerable<ImageDto>> GetAllImagesAsync(bool trackChanges)
        {
            var image = await _manager.ImageRepository.GetAllImagesAsync(trackChanges);
            return _mapper.Map<IEnumerable<ImageDto>>(image);
        }

        public async Task<ImageDto> GetImageByIdAsync(int id, bool trackChanges)
        {
            var image = await _manager.ImageRepository.GetImageByIdAsync(id, trackChanges);
            return _mapper.Map<ImageDto>(image);
        }

        public async Task<ImageDto> SortImageAsync(int id, int newSort, bool trackChanges)
        {
            var image = await _manager.ImageRepository.SortImageAsync(id, newSort, trackChanges);
            return _mapper.Map<ImageDto>(image);
        }

        public async Task<ImageDto> UpdateImageAsync(int id, ImageDtoForUpdate imageDtoForUpdate, bool trackChanges)
        {
            var image = await _manager.ImageRepository.GetImageByIdAsync(id, trackChanges);
            image = _mapper.Map<Image>(imageDtoForUpdate);
            _manager.ImageRepository.UpdateImage(image);
            await _manager.SaveAsync();
            return _mapper.Map<ImageDto>(image);
        }
    }
}
