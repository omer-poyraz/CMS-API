namespace Repositories.Contracts
{
    public interface IRepositoryManager
    {
        IBlogRepository BlogRepository { get; }
        IFormRepository FormRepository { get; }
        IFormElementRepository FormElementRepository { get; }
        IFormResponseRepository FormResponseRepository { get; }
        IGalleryRepository GalleryRepository { get; }
        ILanguageRepository LanguageRepository { get; }
        ILibraryModelRepository LibraryModelRepository { get; }
        ILogRepository LogRepository { get; }
        IModuleRepository ModuleRepository { get; }
        IModuleContentRepository ModuleContentRepository { get; }
        IModuleFieldRepository ModuleFieldRepository { get; }
        IServicesRepository ServicesRepository { get; }
        IUserRepository UserRepository { get; }
        IUserPermissionRepository UserPermissionRepository { get; }

        Task SaveAsync();
    }
}
