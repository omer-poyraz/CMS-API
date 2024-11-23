using Entities.Models;

namespace Repositories.Contracts
{
    public interface IDealerRepository : IRepositoryBase<Dealer>
    {
        Task<IEnumerable<Dealer>> GetAllDealersAsync(bool trackChanges);
        Task<IEnumerable<Dealer>> GetAllDealersByContactAsync(int id, bool trackChanges);
        Task<Dealer> GetDealerByIdAsync(int id, bool trackChanges);
        Dealer CreateDealer(Dealer dealerGroup);
        Dealer UpdateDealer(Dealer dealerGroup);
        Dealer DeleteDealer(Dealer dealerGroup);
    }
}
