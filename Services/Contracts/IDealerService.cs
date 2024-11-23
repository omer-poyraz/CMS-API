using Entities.DTOs.DealerDto;

namespace Services.Contracts
{
    public interface IDealerService
    {
        Task<IEnumerable<DealerDto>> GetAllDealersAsync(bool trackChanges);
        Task<IEnumerable<DealerDto>> GetAllDealersByContactAsync(int id, bool trackChanges);
        Task<DealerDto> GetDealerByIdAsync(int id, bool trackChanges);
        Task<DealerDto> CreateDealerAsync(DealerDtoForInsertion dealerDtoForInsertion);
        Task<DealerDto> UpdateDealerAsync(int id, DealerDtoForUpdate dealerDtoForUpdate, bool trackChanges);
        Task<DealerDto> DeleteDealerAsync(int id, bool trackChanges); 
    }
}
