namespace Repositories.Contracts
{
    public interface IRepositoryManager
    {
        IBlogRepository BlogRepository { get; }
        ILogRepository LogRepository { get; }
        IServicesRepository ServicesRepository { get; }
        IUserRepository UserRepository { get; }
        IUserPermissionRepository UserPermissionRepository { get; }

        Task SaveAsync();
    }
}
