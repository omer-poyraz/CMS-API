namespace Services.Contracts
{
    public interface IServiceManager
    {
        IAuthenticationService AuthenticationService { get; }
        IUserService UserService { get; }
        IUserPermissionService UserPermissionService { get; }
        IServicesService ServicesService { get; }
    }
}
