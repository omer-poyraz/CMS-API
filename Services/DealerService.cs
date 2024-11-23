using AutoMapper;
using Entities.DTOs.DealerDto;
using Entities.Models;
using Repositories.Contracts;
using Services.Contracts;

namespace Services
{
    public class DealerService : IDealerService
    {
        private readonly IRepositoryManager _manager;
        private readonly IMapper _mapper;
        public DealerService(IRepositoryManager manager, IMapper mapper)
        {
            _manager = manager;
            _mapper = mapper;
        }

        public async Task<DealerDto> CreateDealerAsync(DealerDtoForInsertion dealerDtoForInsertion)
        {
            var dealer = _mapper.Map<Dealer>(dealerDtoForInsertion);
            _manager.DealerRepository.CreateDealer(dealer);
            await _manager.SaveAsync();
            return _mapper.Map<DealerDto>(dealer);
        }

        public async Task<DealerDto> DeleteDealerAsync(int id, bool trackChanges)
        {
            var dealer = await _manager.DealerRepository.GetDealerByIdAsync(id, trackChanges);
            _manager.DealerRepository.DeleteDealer(dealer);
            await _manager.SaveAsync();
            return _mapper.Map<DealerDto>(dealer);
        }

        public async Task<IEnumerable<DealerDto>> GetAllDealersAsync(bool trackChanges)
        {
            var dealer = await _manager.DealerRepository.GetAllDealersAsync(trackChanges);
            return _mapper.Map<IEnumerable<DealerDto>>(dealer);
        }

        public async Task<IEnumerable<DealerDto>> GetAllDealersByContactAsync(int id, bool trackChanges)
        {
            var dealer = await _manager.DealerRepository.GetAllDealersByContactAsync(id, trackChanges);
            return _mapper.Map<IEnumerable<DealerDto>>(dealer);
        }

        public async Task<DealerDto> GetDealerByIdAsync(int id, bool trackChanges)
        {
            var dealer = await _manager.DealerRepository.GetDealerByIdAsync(id, trackChanges);
            return _mapper.Map<DealerDto>(dealer);
        }

        public async Task<DealerDto> UpdateDealerAsync(int id, DealerDtoForUpdate dealerDtoForUpdate, bool trackChanges)
        {
            var dealer = await _manager.DealerRepository.GetDealerByIdAsync(id, trackChanges);
            dealer = _mapper.Map<Dealer>(dealerDtoForUpdate);
            _manager.DealerRepository.UpdateDealer(dealer);
            await _manager.SaveAsync();
            return _mapper.Map<DealerDto>(dealer);
        }
    }
}
