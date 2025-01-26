using Entities.Models;

namespace Repositories.Contracts
{
    public interface ILogRepository : IRepositoryBase<Log>
    {
        Task<IEnumerable<Log>> GetAllLogsAsync(bool trackChanges);
        Task<Log> GetLogByIdAsync(int id, bool trackChanges);
        Log CreateLog(Log log);
        Log DeleteLog(Log log);
    }
}
