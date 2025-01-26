using Entities.Models;

namespace Repositories.Contracts
{
    public interface IServicesRepository : IRepositoryBase<Services>
    {
        Task<IEnumerable<Services>> GetAllServicesAsync(bool trackChanges);
        Task<Services> GetServicesByIdAsync(int id, bool trackChanges);
        Services CreateServices(Services services);
        Services UpdateServices(Services services);
        Services DeleteServices(Services services);
    }
}
