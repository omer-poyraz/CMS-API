using Entities.Models;

namespace Repositories.Contracts
{
    public interface IModuleFieldRepository : IRepositoryBase<ModuleField>
    {
        Task<IEnumerable<ModuleField>> GetAllModuleFieldsAsync(bool trackChanges);
        Task<ModuleField> GetModuleFieldByIdAsync(int id, bool trackChanges);
        Task<ModuleField> GetModuleFieldBySlugAsync(string slug, bool trackChanges);
        Task<ModuleField> SortModuleFieldAsync(int id, int sort, bool trackChanges);
        ModuleField CreateModuleField(ModuleField moduleField);
        ModuleField UpdateModuleField(ModuleField moduleField);
        ModuleField DeleteModuleField(ModuleField moduleField);
    }
}
