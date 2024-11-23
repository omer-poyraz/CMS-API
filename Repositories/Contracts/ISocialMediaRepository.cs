using Entities.Models;

namespace Repositories.Contracts
{
    public interface ISocialMediaRepository : IRepositoryBase<SocialMedia>
    {
        Task<IEnumerable<SocialMedia>> GetAllSocialMediasAsync(bool trackChanges);
        Task<SocialMedia> GetSocialMediaByIdAsync(int id, bool trackChanges);
        SocialMedia CreateSocialMedia(SocialMedia socialMediaGroup);
        SocialMedia UpdateSocialMedia(SocialMedia socialMediaGroup);
        SocialMedia DeleteSocialMedia(SocialMedia socialMediaGroup);
    }
}
