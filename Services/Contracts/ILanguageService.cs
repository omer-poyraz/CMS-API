using Entities.DTOs.LanguageDto;

namespace Services.Contracts
{
    public interface ILanguageService
    {
        Task<IEnumerable<LanguageDto>> GetAllLanguagesAsync(bool trackChanges);
        Task<LanguageDto> GetLanguageByIdAsync(int id, bool trackChanges);
        Task<LanguageDto> CreateLanguageAsync(LanguageDtoForInsertion languageDtoForInsertion);
        Task<LanguageDto> UpdateLanguageAsync(
            int id,
            LanguageDtoForUpdate languageDtoForUpdate,
            bool trackChanges
        );
        Task<LanguageDto> DeleteLanguageAsync(int id, bool trackChanges);
    }
}
