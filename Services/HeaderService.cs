using AutoMapper;
using Entities.DTOs.HeaderDto;
using Entities.Models;
using Repositories.Contracts;
using Services.Contracts;

namespace Services
{
    public class HeaderService : IHeaderService
    {
        private readonly IRepositoryManager _manager;
        private readonly IMapper _mapper;
        public HeaderService(IRepositoryManager manager, IMapper mapper)
        {
            _manager = manager;
            _mapper = mapper;
        }

        public async Task<HeaderDto> CreateHeaderAsync(HeaderDtoForInsertion headerDtoForInsertion)
        {
            var header = _mapper.Map<Header>(headerDtoForInsertion);
            _manager.HeaderRepository.CreateHeader(header);
            await _manager.SaveAsync();
            return _mapper.Map<HeaderDto>(header);
        }

        public async Task<HeaderDto> DeleteHeaderAsync(int id, bool trackChanges)
        {
            var header = await _manager.HeaderRepository.GetHeaderByIdAsync(id, trackChanges);
            _manager.HeaderRepository.DeleteHeader(header);
            await _manager.SaveAsync();
            return _mapper.Map<HeaderDto>(header);
        }

        public async Task<HeaderDto> SortHeaderAsync(int id, int newSort, bool trackChanges){
            var header = await _manager.HeaderRepository.SortHeaderAsync(id, newSort, trackChanges);
            await _manager.SaveAsync();
            return _mapper.Map<HeaderDto>(header);
        }

        public async Task<IEnumerable<HeaderDto>> GetAllHeadersAsync(bool trackChanges)
        {
            var header = await _manager.HeaderRepository.GetAllHeadersAsync(trackChanges);
            return _mapper.Map<IEnumerable<HeaderDto>>(header);
        }

        public async Task<HeaderDto> GetHeaderByIdAsync(int id, bool trackChanges)
        {
            var header = await _manager.HeaderRepository.GetHeaderByIdAsync(id, trackChanges);
            return _mapper.Map<HeaderDto>(header);
        }

        public async Task<HeaderDto> UpdateHeaderAsync(int id, HeaderDtoForUpdate headerDtoForUpdate, bool trackChanges)
        {
            var header = await _manager.HeaderRepository.GetHeaderByIdAsync(id, trackChanges);
            header = _mapper.Map<Header>(headerDtoForUpdate);
            _manager.HeaderRepository.UpdateHeader(header);
            await _manager.SaveAsync();
            return _mapper.Map<HeaderDto>(header);
        }
    }
}
