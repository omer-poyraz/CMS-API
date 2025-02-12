using Entities.Models;

namespace Repositories.Contracts
{
    public interface IModuleContentRepository : IRepositoryBase<ModuleContent>
    {
        Task<IEnumerable<ModuleContent>> GetAllModuleContentsAsync(bool trackChanges);
        Task<ModuleContent> GetModuleContentByIdAsync(int id, bool trackChanges);
        Task<ModuleContent> GetModuleContentBySlugAsync(string slug, bool trackChanges);
        Task<ModuleContent> SortModuleContentAsync(int id, int sort, bool trackChanges);
        ModuleContent CreateModuleContent(ModuleContent moduleContent);
        ModuleContent UpdateModuleContent(ModuleContent moduleContent);
        ModuleContent DeleteModuleContent(ModuleContent moduleContent);
    }
}
