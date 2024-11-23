namespace Services.Contracts
{
    public interface ILogService
    {
        Task AppendTextToFileAsync(string fileName, string content);
        Task<object> GetAllServices(int id);
        Task DeleteLogService(int id, int crud);
    }
}
