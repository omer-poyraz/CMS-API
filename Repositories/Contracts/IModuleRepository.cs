using Entities.Models;

namespace Repositories.Contracts
{
    public interface IModuleRepository : IRepositoryBase<Module>
    {
        Task<IEnumerable<Module>> GetAllModulesAsync(bool trackChanges);
        Task<Module> GetModuleByIdAsync(int id, bool trackChanges);
        Task<Module> GetModuleBySlugAsync(string slug, bool trackChanges);
        Task<Module> SortModuleAsync(int id, int sort, bool trackChanges);
        Module CreateModule(Module module);
        Module UpdateModule(Module module);
        Module DeleteModule(Module module);
    }
}
