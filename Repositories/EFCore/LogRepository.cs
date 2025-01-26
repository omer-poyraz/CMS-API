using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Repositories.Contracts;

namespace Repositories.EFCore
{
    public class LogRepository : RepositoryBase<Log>, ILogRepository
    {
        public LogRepository(RepositoryContext context)
            : base(context) { }

        public Log CreateLog(Log log)
        {
            Create(log);
            return log;
        }

        public Log DeleteLog(Log log)
        {
            Delete(log);
            return log;
        }

        public async Task<IEnumerable<Log>> GetAllLogsAsync(bool trackChanges) =>
            await FindAll(trackChanges).OrderBy(s => s.ID).Include(s => s.User).ToListAsync();

        public async Task<Log> GetLogByIdAsync(int id, bool trackChanges) =>
            await FindByCondition(s => s.ID.Equals(id), trackChanges)
                .Include(s => s.User)
                .SingleOrDefaultAsync();
    }
}
