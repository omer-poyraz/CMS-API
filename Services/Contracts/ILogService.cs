using Entities.DTOs.LogDto;

namespace Services.Contracts
{
    public interface ILogService
    {
        Task<IEnumerable<LogDto>> GetAllLogsAsync(bool trackChanges);
        Task<LogDto> GetLogByIdAsync(int id, bool trackChanges);
        Task<LogDto> CreateLogAsync(LogDtoForInsertion logDtoForInsertion);
        Task<LogDto> DeleteLogAsync(int id, bool trackChanges);
    }
}
