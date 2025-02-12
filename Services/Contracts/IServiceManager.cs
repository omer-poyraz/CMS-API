namespace Services.Contracts
{
    public interface IServiceManager
    {
        IAuthenticationService AuthenticationService { get; }
        IBlogService BlogService { get; }
        IFormService FormService { get; }
        IFormElementService FormElementService { get; }
        IFormResponseService FormResponseService { get; }
        IGalleryService GalleryService { get; }
        ILanguageService LanguageService { get; }
        ILibraryModelService LibraryModelService { get; }
        ILogService LogService { get; }
        IModuleService ModuleService { get; }
        IModuleContentService ModuleContentService { get; }
        IModuleFieldService ModuleFieldService { get; }
        IServicesService ServicesService { get; }
        IUserService UserService { get; }
        IUserPermissionService UserPermissionService { get; }
    }
}
