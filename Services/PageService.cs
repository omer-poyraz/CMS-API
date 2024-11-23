using AutoMapper;
using Entities.DTOs.PageDto;
using Entities.Models;
using Repositories.Contracts;
using Services.Contracts;

namespace Services
{
    public class PageService : IPageService
    {
        private readonly IRepositoryManager _manager;
        private readonly IMapper _mapper;
        public PageService(IRepositoryManager manager, IMapper mapper)
        {
            _manager = manager;
            _mapper = mapper;
        }

        public async Task<PageDto> CreatePageAsync(PageDtoForInsertion pageDtoForInsertion)
        {
            var page = _mapper.Map<Page>(pageDtoForInsertion);
            _manager.PageRepository.CreatePage(page);
            await _manager.SaveAsync();
            return _mapper.Map<PageDto>(page);
        }

        public async Task<PageDto> DeletePageAsync(int id, bool trackChanges)
        {
            var page = await _manager.PageRepository.GetPageByIdAsync(id, trackChanges);
            _manager.PageRepository.DeletePage(page);
            await _manager.SaveAsync();
            return _mapper.Map<PageDto>(page);
        }

        public async Task<IEnumerable<PageDto>> GetAllPagesAsync(bool trackChanges)
        {
            var page = await _manager.PageRepository.GetAllPagesAsync(trackChanges);
            return _mapper.Map<IEnumerable<PageDto>>(page);
        }

        public async Task<PageDto> GetPageByHeaderIdAsync(int id, bool trackChanges)
        {
            var page = await _manager.PageRepository.GetPageByHeaderIdAsync(id, trackChanges);
            return _mapper.Map<PageDto>(page);
        }

        public async Task<PageDto> GetPageByHeaderURLAsync(string url, bool trackChanges)
        {
            var page = await _manager.PageRepository.GetPageByHeaderURLAsync(url, trackChanges);
            return _mapper.Map<PageDto>(page);
        }

        public async Task<PageDto> GetPageByIdAsync(int id, bool trackChanges)
        {
            var page = await _manager.PageRepository.GetPageByIdAsync(id, trackChanges);
            return _mapper.Map<PageDto>(page);
        }

        public async Task<PageDto> UpdatePageAsync(int id, PageDtoForUpdate pageDtoForUpdate, bool trackChanges)
        {
            var page = await _manager.PageRepository.GetPageByIdAsync(id, trackChanges);
            page = _mapper.Map<Page>(pageDtoForUpdate);
            _manager.PageRepository.UpdatePage(page);
            await _manager.SaveAsync();
            return _mapper.Map<PageDto>(page);
        }
    }
}
