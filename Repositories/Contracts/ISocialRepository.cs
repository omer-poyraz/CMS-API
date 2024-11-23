using Entities.Models;

namespace Repositories.Contracts
{
    public interface ISocialRepository : IRepositoryBase<Social>
    {
        Task<IEnumerable<Social>> GetAllSocialsAsync(bool trackChanges);
        Task<IEnumerable<Social>> GetAllSocialsBySocialAsync(int id, bool trackChanges);
        Task<Social> GetSocialByIdAsync(int id, bool trackChanges);
        Social CreateSocial(Social socialGroup);
        Social UpdateSocial(Social socialGroup);
        Social DeleteSocial(Social socialGroup);
    }
}
