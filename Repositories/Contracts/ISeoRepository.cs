using Entities.Models;

namespace Repositories.Contracts
{
    public interface ISeoRepository : IRepositoryBase<Seo>
    {
        Task<IEnumerable<Seo>> GetAllSeosAsync(bool trackChanges);
        Task<Seo> GetSeoByIdAsync(int id, bool trackChanges);
        Seo CreateSeo(Seo seo);
        Seo UpdateSeo(Seo seo);
        Seo DeleteSeo(Seo seo);
    }
}
