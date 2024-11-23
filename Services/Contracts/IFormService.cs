using Entities.DTOs.FormDto;

namespace Services.Contracts
{
    public interface IFormService
    {
        Task<IEnumerable<FormDto>> GetAllFormsAsync(bool trackChanges);
        Task<FormDto> GetFormByIdAsync(int id, bool trackChanges);
        Task<FormDto> CreateFormAsync(FormDtoForInsertion formDtoForInsertion);
        Task<FormDto> UpdateFormAsync(int id, FormDtoForUpdate formDtoForUpdate, bool trackChanges);
        Task<FormDto> DeleteFormAsync(int id, bool trackChanges);
    }
}
