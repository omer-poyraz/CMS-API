using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Repositories.Contracts;

namespace Repositories.EFCore
{
    public class ServicesRepository : RepositoryBase<Services>, IServicesRepository
    {
        public ServicesRepository(RepositoryContext context)
            : base(context) { }

        public Services CreateServices(Services services)
        {
            Create(services);
            return services;
        }

        public Services DeleteServices(Services services)
        {
            Delete(services);
            return services;
        }

        public async Task<IEnumerable<Services>> GetAllServicesAsync(bool trackChanges) =>
            await FindAll(trackChanges).OrderBy(s => s.ID).Include(s => s.User).ToListAsync();

        public async Task<Services> GetServicesByIdAsync(int id, bool trackChanges) =>
            await FindByCondition(s => s.ID.Equals(id), trackChanges)
                .Include(s => s.User)
                .SingleOrDefaultAsync();

        public Services UpdateServices(Services services)
        {
            Update(services);
            return services;
        }
    }
}
