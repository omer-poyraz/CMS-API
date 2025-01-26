namespace Repositories.Contracts
{
    public interface IRepositoryManager
    {
        IUserRepository UserRepository { get; }
        IUserPermissionRepository UserPermissionRepository { get; }

        Task SaveAsync();
    }
}
