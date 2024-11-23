namespace Repositories.Contracts
{
    public interface IRepositoryManager
    {
        IUserRepository UserRepository { get; }
        IFormRepository FormRepository { get; }
        IContactRepository ContactRepository { get; }
        IDealerRepository DealerRepository { get; }
        ISocialRepository SocialRepository { get; }
        ISocialMediaRepository SocialMediaRepository { get; }
        IHeaderRepository HeaderRepository { get; }
        ISettingRepository SettingRepository { get; }
        ISliderRepository SliderRepository { get; }
        ISliderGroupRepository SliderGroupRepository { get; }
        IProductRepository ProductRepository { get; }
        IProductGroupRepository ProductGroupRepository { get; }
        ISeoRepository SeoRepository { get; }
        IDocumentRepository DocumentRepository { get; }
        IDocumentGroupRepository DocumentGroupRepository { get; }
        IPageRepository PageRepository { get; }
        IImageRepository ImageRepository { get; }
        IImageGroupRepository ImageGroupRepository { get; }

        Task SaveAsync();
    }
}
