using Entities.Models;

namespace Repositories.Contracts
{
    public interface IPageRepository : IRepositoryBase<Page>
    {
        Task<IEnumerable<Page>> GetAllPagesAsync(bool trackChanges);
        Task<Page> GetPageByIdAsync(int id, bool trackChanges);
        Task<Page> GetPageByHeaderIdAsync(int id, bool trackChanges);
        Task<Page> GetPageByHeaderURLAsync(string url, bool trackChanges);
        Page CreatePage(Page page);
        Page UpdatePage(Page page);
        Page DeletePage(Page page);
    }
}
