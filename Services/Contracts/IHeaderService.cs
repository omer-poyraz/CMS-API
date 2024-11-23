using Entities.DTOs.HeaderDto;

namespace Services.Contracts
{
    public interface IHeaderService
    {
        Task<IEnumerable<HeaderDto>> GetAllHeadersAsync(bool trackChanges);
        Task<HeaderDto> GetHeaderByIdAsync(int id, bool trackChanges);
        Task<HeaderDto> SortHeaderAsync(int id, int newSort, bool trackChanges);
        Task<HeaderDto> CreateHeaderAsync(HeaderDtoForInsertion headerDtoForInsertion);
        Task<HeaderDto> UpdateHeaderAsync(int id, HeaderDtoForUpdate headerDtoForUpdate, bool trackChanges);
        Task<HeaderDto> DeleteHeaderAsync(int id, bool trackChanges);
    }
}
