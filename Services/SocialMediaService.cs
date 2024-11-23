using AutoMapper;
using Entities.DTOs.SocialMediaDto;
using Entities.Models;
using Repositories.Contracts;
using Services.Contracts;

namespace Services
{
    public class SocialMediaService : ISocialMediaService
    {
        private readonly IRepositoryManager _manager;
        private readonly IMapper _mapper;
        public SocialMediaService(IRepositoryManager manager, IMapper mapper)
        {
            _manager = manager;
            _mapper = mapper;
        }

        public async Task<SocialMediaDto> CreateSocialMediaAsync(SocialMediaDtoForInsertion socialMediaDtoForInsertion)
        {
            var socialMedia = _mapper.Map<SocialMedia>(socialMediaDtoForInsertion);
            _manager.SocialMediaRepository.CreateSocialMedia(socialMedia);
            await _manager.SaveAsync();
            return _mapper.Map<SocialMediaDto>(socialMedia);
        }

        public async Task<SocialMediaDto> DeleteSocialMediaAsync(int id, bool trackChanges)
        {
            var socialMedia = await _manager.SocialMediaRepository.GetSocialMediaByIdAsync(id, trackChanges);
            _manager.SocialMediaRepository.DeleteSocialMedia(socialMedia);
            await _manager.SaveAsync();
            return _mapper.Map<SocialMediaDto>(socialMedia);
        }

        public async Task<IEnumerable<SocialMediaDto>> GetAllSocialMediasAsync(bool trackChanges)
        {
            var socialMedia = await _manager.SocialMediaRepository.GetAllSocialMediasAsync(trackChanges);
            return _mapper.Map<IEnumerable<SocialMediaDto>>(socialMedia);
        }

        public async Task<SocialMediaDto> GetSocialMediaByIdAsync(int id, bool trackChanges)
        {
            var socialMedia = await _manager.SocialMediaRepository.GetSocialMediaByIdAsync(id, trackChanges);
            return _mapper.Map<SocialMediaDto>(socialMedia);
        }

        public async Task<SocialMediaDto> UpdateSocialMediaAsync(int id, SocialMediaDtoForUpdate socialMediaDtoForUpdate, bool trackChanges)
        {
            var socialMedia = await _manager.SocialMediaRepository.GetSocialMediaByIdAsync(id, trackChanges);
            socialMedia = _mapper.Map<SocialMedia>(socialMediaDtoForUpdate);
            _manager.SocialMediaRepository.UpdateSocialMedia(socialMedia);
            await _manager.SaveAsync();
            return _mapper.Map<SocialMediaDto>(socialMedia);
        }
    }
}
