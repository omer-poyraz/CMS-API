namespace Repositories.Contracts
{
    public interface IRepositoryManager
    {
        IUserRepository UserRepository { get; }
        IUserPermissionRepository UserPermissionRepository { get; }
        IServicesRepository ServicesRepository { get; }
        ILogRepository LogRepository { get; }

        Task SaveAsync();
    }
}
