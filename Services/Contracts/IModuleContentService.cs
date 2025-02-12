using Entities.DTOs.ModuleContentDto;

namespace Services.Contracts
{
    public interface IModuleContentService
    {
        Task<IEnumerable<ModuleContentDto>> GetAllModuleContentsAsync(bool trackChanges);
        Task<ModuleContentDto> GetModuleContentByIdAsync(int id, bool trackChanges);
        Task<ModuleContentDto> GetModuleContentBySlugAsync(string slug, bool trackChanges);
        Task<ModuleContentDto> SortModuleContentAsync(int id, int sort, bool trackChanges);
        Task<ModuleContentDto> CreateModuleContentAsync(
            ModuleContentDtoForInsertion moduleContentDtoForInsertion
        );
        Task<ModuleContentDto> UpdateModuleContentAsync(
            int id,
            ModuleContentDtoForUpdate moduleContentDtoForUpdate,
            bool trackChanges
        );
        Task<ModuleContentDto> DeleteModuleContentAsync(int id, bool trackChanges);
    }
}
