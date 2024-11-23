using Entities.DTOs.SocialMediaDto;

namespace Services.Contracts
{
    public interface ISocialMediaService
    {
        Task<IEnumerable<SocialMediaDto>> GetAllSocialMediasAsync(bool trackChanges);
        Task<SocialMediaDto> GetSocialMediaByIdAsync(int id, bool trackChanges);
        Task<SocialMediaDto> CreateSocialMediaAsync(SocialMediaDtoForInsertion socialMediaDtoForInsertion);
        Task<SocialMediaDto> UpdateSocialMediaAsync(int id, SocialMediaDtoForUpdate socialMediaDtoForUpdate, bool trackChanges);
        Task<SocialMediaDto> DeleteSocialMediaAsync(int id, bool trackChanges); 
    }
}
