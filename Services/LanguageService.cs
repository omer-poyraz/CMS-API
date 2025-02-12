using AutoMapper;
using Entities.DTOs.LanguageDto;
using Entities.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Repositories.Contracts;
using Repositories.EFCore;
using Services.Contracts;
using Services.Extensions;

namespace Services
{
    public class LanguageService : ILanguageService
    {
        private readonly IRepositoryManager _manager;
        private readonly RepositoryContext _context;
        private readonly IMapper _mapper;

        public LanguageService(
            IRepositoryManager manager,
            IMapper mapper,
            RepositoryContext context
        )
        {
            _manager = manager;
            _mapper = mapper;
            _context = context;
        }

        public async Task<LanguageDto> CreateLanguageAsync(
            LanguageDtoForInsertion languageGroupDtoForInsertion
        )
        {
            var languageGroup = _mapper.Map<Entities.Models.Language>(languageGroupDtoForInsertion);
            _manager.LanguageRepository.CreateLanguage(languageGroup);
            await _manager.SaveAsync();
            return _mapper.Map<LanguageDto>(languageGroup);
        }

        public async Task<LanguageDto> DeleteLanguageAsync(int id, bool trackChanges)
        {
            var languageGroup = await _manager.LanguageRepository.GetLanguageByIdAsync(
                id,
                trackChanges
            );
            _manager.LanguageRepository.DeleteLanguage(languageGroup);
            await _manager.SaveAsync();
            return _mapper.Map<LanguageDto>(languageGroup);
        }

        public async Task<IEnumerable<LanguageDto>> GetAllLanguagesAsync(bool trackChanges)
        {
            var languageGroup = await _manager.LanguageRepository.GetAllLanguagesAsync(
                trackChanges
            );
            return _mapper.Map<IEnumerable<LanguageDto>>(languageGroup);
        }

        public async Task<LanguageDto> GetLanguageByIdAsync(int id, bool trackChanges)
        {
            var languageGroup = await _manager.LanguageRepository.GetLanguageByIdAsync(
                id,
                trackChanges
            );
            return _mapper.Map<LanguageDto>(languageGroup);
        }

        public async Task<LanguageDto> UpdateLanguageAsync(
            int id,
            LanguageDtoForUpdate languageGroupDtoForUpdate,
            bool trackChanges
        )
        {
            var languageGroup = await _manager.LanguageRepository.GetLanguageByIdAsync(
                id,
                trackChanges
            );
            languageGroup = _mapper.Map<Entities.Models.Language>(languageGroupDtoForUpdate);
            _manager.LanguageRepository.UpdateLanguage(languageGroup);
            await _manager.SaveAsync();
            return _mapper.Map<LanguageDto>(languageGroup);
        }
    }
}
