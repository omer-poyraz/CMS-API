using Entities.DTOs.PageDto;

namespace Services.Contracts
{
    public interface IPageService
    {
        Task<IEnumerable<PageDto>> GetAllPagesAsync(bool trackChanges);
        Task<PageDto> GetPageByIdAsync(int id, bool trackChanges);
        Task<PageDto> GetPageByHeaderIdAsync(int id, bool trackChanges);
        Task<PageDto> GetPageByHeaderURLAsync(string url, bool trackChanges);
        Task<PageDto> CreatePageAsync(PageDtoForInsertion pageDtoForInsertion);
        Task<PageDto> UpdatePageAsync(int id, PageDtoForUpdate pageDtoForUpdate, bool trackChanges);
        Task<PageDto> DeletePageAsync(int id, bool trackChanges);
    }
}
