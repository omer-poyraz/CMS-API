using Entities.Models;

namespace Repositories.Contracts
{
    public interface IHeaderRepository : IRepositoryBase<Header>
    {
        Task<IEnumerable<Header>> GetAllHeadersAsync(bool trackChanges);
        Task<Header> GetHeaderByIdAsync(int id, bool trackChanges);
        Task<Header> SortHeaderAsync(int id, int newSort, bool trackChanges);
        Task<Header> CreateHeader(Header Header);
        Header UpdateHeader(Header Header);
        Header DeleteHeader(Header Header);
    }
}
