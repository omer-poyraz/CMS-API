using Entities.DTOs.ModuleFieldDto;

namespace Services.Contracts
{
    public interface IModuleFieldService
    {
        Task<IEnumerable<ModuleFieldDto>> GetAllModuleFieldsAsync(bool trackChanges);
        Task<ModuleFieldDto> GetModuleFieldByIdAsync(int id, bool trackChanges);
        Task<ModuleFieldDto> GetModuleFieldBySlugAsync(string slug, bool trackChanges);
        Task<ModuleFieldDto> SortModuleFieldAsync(int id, int sort, bool trackChanges);
        Task<ModuleFieldDto> CreateModuleFieldAsync(
            ModuleFieldDtoForInsertion moduleFieldDtoForInsertion
        );
        Task<ModuleFieldDto> UpdateModuleFieldAsync(
            int id,
            ModuleFieldDtoForUpdate moduleFieldDtoForUpdate,
            bool trackChanges
        );
        Task<ModuleFieldDto> DeleteModuleFieldAsync(int id, bool trackChanges);
    }
}
