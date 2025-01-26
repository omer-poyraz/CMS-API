using AutoMapper;
using Entities.DTOs.LogDto;
using Entities.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Repositories.Contracts;
using Repositories.EFCore;
using Services.Contracts;

namespace Services
{
    public class LogService : ILogService
    {
        private readonly IRepositoryManager _manager;
        private readonly RepositoryContext _context;
        private readonly IMapper _mapper;

        public LogService(IRepositoryManager manager, IMapper mapper, RepositoryContext context)
        {
            _manager = manager;
            _mapper = mapper;
            _context = context;
        }

        public async Task<LogDto> CreateLogAsync(LogDtoForInsertion logDtoForInsertion)
        {
            var log = _mapper.Map<Log>(logDtoForInsertion);
            _manager.LogRepository.CreateLog(log);
            await _manager.SaveAsync();
            return _mapper.Map<LogDto>(log);
        }

        public async Task<LogDto> DeleteLogAsync(int id, bool trackChanges)
        {
            var log = await _manager.LogRepository.GetLogByIdAsync(id, trackChanges);
            _manager.LogRepository.DeleteLog(log);
            await _manager.SaveAsync();
            return _mapper.Map<LogDto>(log);
        }

        public async Task<IEnumerable<LogDto>> GetAllLogsAsync(bool trackChanges)
        {
            var log = await _manager.LogRepository.GetAllLogsAsync(trackChanges);
            return _mapper.Map<IEnumerable<LogDto>>(log);
        }

        public async Task<LogDto> GetLogByIdAsync(int id, bool trackChanges)
        {
            var log = await _manager.LogRepository.GetLogByIdAsync(id, trackChanges);
            return _mapper.Map<LogDto>(log);
        }
    }
}
