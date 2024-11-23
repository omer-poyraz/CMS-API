using AutoMapper;
using Entities.DTOs.SeoDto;
using Entities.Models;
using Repositories.Contracts;
using Services.Contracts;

namespace Services
{
    public class SeoService : ISeoService
    {
        private readonly IRepositoryManager _manager;
        private readonly IMapper _mapper;
        public SeoService(IRepositoryManager manager, IMapper mapper)
        {
            _manager = manager;
            _mapper = mapper;
        }

        public async Task<SeoDto> CreateSeoAsync(SeoDtoForInsertion seoDtoForInsertion)
        {
            var seo = _mapper.Map<Seo>(seoDtoForInsertion);
            _manager.SeoRepository.CreateSeo(seo);
            await _manager.SaveAsync();
            return _mapper.Map<SeoDto>(seo);
        }

        public async Task<SeoDto> DeleteSeoAsync(int id, bool trackChanges)
        {
            var seo = await _manager.SeoRepository.GetSeoByIdAsync(id, trackChanges);
            _manager.SeoRepository.DeleteSeo(seo);
            await _manager.SaveAsync();
            return _mapper.Map<SeoDto>(seo);
        }

        public async Task<IEnumerable<SeoDto>> GetAllSeosAsync(bool trackChanges)
        {
            var seo = await _manager.SeoRepository.GetAllSeosAsync(trackChanges);
            return _mapper.Map<IEnumerable<SeoDto>>(seo);
        }

        public async Task<SeoDto> GetSeoByIdAsync(int id, bool trackChanges)
        {
            var seo = await _manager.SeoRepository.GetSeoByIdAsync(id, trackChanges);
            return _mapper.Map<SeoDto>(seo);
        }

        public async Task<SeoDto> UpdateSeoAsync(int id, SeoDtoForUpdate seoDtoForUpdate, bool trackChanges)
        {
            var seo = await _manager.SeoRepository.GetSeoByIdAsync(id, trackChanges);
            seo = _mapper.Map<Seo>(seoDtoForUpdate);
            _manager.SeoRepository.UpdateSeo(seo);
            await _manager.SaveAsync();
            return _mapper.Map<SeoDto>(seo);
        }
    }
}
