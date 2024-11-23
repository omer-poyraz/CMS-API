using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Repositories.Contracts;

namespace Repositories.EFCore
{
    public class DealerRepository : RepositoryBase<Dealer>, IDealerRepository
    {
        public DealerRepository(RepositoryContext context) : base(context)
        {
        }

        public Dealer CreateDealer(Dealer dealer)
        {
            Create(dealer);
            return dealer;
        }

        public Dealer DeleteDealer(Dealer dealer)
        {
            Delete(dealer);
            return dealer;
        }

        public async Task<IEnumerable<Dealer>> GetAllDealersAsync(bool trackChanges) => await FindAll(trackChanges)
            .OrderBy(s=>s.DealerID)
            .Include(s=>s.User)
            .Include(s=>s.SocialMedia)
            .Include(s=>s.Contact)
            .ToListAsync();

        public async Task<IEnumerable<Dealer>> GetAllDealersByContactAsync(int id, bool trackChanges) => await FindAll(trackChanges)
            .Where(s=>s.ContactID == id)
            .OrderBy(s=>s.DealerID)
            .Include(s=>s.User)
            .Include(s=>s.SocialMedia)
            .Include(s=>s.Contact)
            .ToListAsync();

        public async Task<Dealer> GetDealerByIdAsync(int id, bool trackChanges) => await FindByCondition(s => s.DealerID.Equals(id), trackChanges)
            .Include(s=>s.User)
            .Include(s=>s.SocialMedia)
            .Include(s=>s.Contact)
            .SingleOrDefaultAsync();

        public Dealer UpdateDealer(Dealer dealer)
        {
            Update(dealer);
            return dealer;
        }
    }
}
