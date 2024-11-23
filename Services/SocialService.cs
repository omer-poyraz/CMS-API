using AutoMapper;
using Entities.DTOs.SocialDto;
using Entities.Models;
using Repositories.Contracts;
using Services.Contracts;

namespace Services
{
    public class SocialService : ISocialService
    {
        private readonly IRepositoryManager _manager;
        private readonly IMapper _mapper;
        public SocialService(IRepositoryManager manager, IMapper mapper)
        {
            _manager = manager;
            _mapper = mapper;
        }

        public async Task<SocialDto> CreateSocialAsync(SocialDtoForInsertion socialDtoForInsertion)
        {
            var social = _mapper.Map<Social>(socialDtoForInsertion);
            _manager.SocialRepository.CreateSocial(social);
            await _manager.SaveAsync();
            return _mapper.Map<SocialDto>(social);
        }

        public async Task<SocialDto> DeleteSocialAsync(int id, bool trackChanges)
        {
            var social = await _manager.SocialRepository.GetSocialByIdAsync(id, trackChanges);
            _manager.SocialRepository.DeleteSocial(social);
            await _manager.SaveAsync();
            return _mapper.Map<SocialDto>(social);
        }

        public async Task<IEnumerable<SocialDto>> GetAllSocialsAsync(bool trackChanges)
        {
            var social = await _manager.SocialRepository.GetAllSocialsAsync(trackChanges);
            return _mapper.Map<IEnumerable<SocialDto>>(social);
        }

        public async Task<IEnumerable<SocialDto>> GetAllSocialsBySocialAsync(int id, bool trackChanges)
        {
            var social = await _manager.SocialRepository.GetAllSocialsBySocialAsync(id, trackChanges);
            return _mapper.Map<IEnumerable<SocialDto>>(social);
        }

        public async Task<SocialDto> GetSocialByIdAsync(int id, bool trackChanges)
        {
            var social = await _manager.SocialRepository.GetSocialByIdAsync(id, trackChanges);
            return _mapper.Map<SocialDto>(social);
        }

        public async Task<SocialDto> UpdateSocialAsync(int id, SocialDtoForUpdate socialDtoForUpdate, bool trackChanges)
        {
            var social = await _manager.SocialRepository.GetSocialByIdAsync(id, trackChanges);
            social = _mapper.Map<Social>(socialDtoForUpdate);
            _manager.SocialRepository.UpdateSocial(social);
            await _manager.SaveAsync();
            return _mapper.Map<SocialDto>(social);
        }
    }
}
