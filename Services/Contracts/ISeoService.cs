using Entities.DTOs.SeoDto;

namespace Services.Contracts
{
    public interface ISeoService
    {
        Task<IEnumerable<SeoDto>> GetAllSeosAsync(bool trackChanges);
        Task<SeoDto> GetSeoByIdAsync(int id, bool trackChanges);
        Task<SeoDto> CreateSeoAsync(SeoDtoForInsertion seoDtoForInsertion);
        Task<SeoDto> UpdateSeoAsync(int id, SeoDtoForUpdate seoDtoForUpdate, bool trackChanges);
        Task<SeoDto> DeleteSeoAsync(int id, bool trackChanges);
    }
}
