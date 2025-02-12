using Entities.DTOs.ModuleDto;

namespace Services.Contracts
{
    public interface IModuleService
    {
        Task<IEnumerable<ModuleDto>> GetAllModulesAsync(bool trackChanges);
        Task<ModuleDto> GetModuleByIdAsync(int id, bool trackChanges);
        Task<ModuleDto> GetModuleBySlugAsync(string slug, bool trackChanges);
        Task<ModuleDto> SortModuleAsync(int id, int sort, bool trackChanges);
        Task<ModuleDto> CreateModuleAsync(ModuleDtoForInsertion moduleDtoForInsertion);
        Task<ModuleDto> UpdateModuleAsync(
            int id,
            ModuleDtoForUpdate moduleDtoForUpdate,
            bool trackChanges
        );
        Task<ModuleDto> DeleteModuleAsync(int id, bool trackChanges);
    }
}
