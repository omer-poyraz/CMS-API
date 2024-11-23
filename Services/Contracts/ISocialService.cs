using Entities.DTOs.SocialDto;

namespace Services.Contracts
{
    public interface ISocialService
    {
        Task<IEnumerable<SocialDto>> GetAllSocialsAsync(bool trackChanges);
        Task<IEnumerable<SocialDto>> GetAllSocialsBySocialAsync(int id, bool trackChanges);
        Task<SocialDto> GetSocialByIdAsync(int id, bool trackChanges);
        Task<SocialDto> CreateSocialAsync(SocialDtoForInsertion socialDtoForInsertion);
        Task<SocialDto> UpdateSocialAsync(int id, SocialDtoForUpdate socialDtoForUpdate, bool trackChanges);
        Task<SocialDto> DeleteSocialAsync(int id, bool trackChanges); 
    }
}
