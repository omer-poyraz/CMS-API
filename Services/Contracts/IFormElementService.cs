using Entities.DTOs.FormElementDto;

namespace Services.Contracts
{
    public interface IFormElementService
    {
        Task<IEnumerable<FormElementDto>> GetAllFormElementsAsync(bool trackChanges);
        Task<FormElementDto> GetFormElementByIdAsync(int id, bool trackChanges);
        Task<FormElementDto> CreateFormElementAsync(
            FormElementDtoForInsertion formElementDtoForInsertion
        );
        Task<FormElementDto> UpdateFormElementAsync(
            int id,
            FormElementDtoForUpdate formElementDtoForUpdate,
            bool trackChanges
        );
        Task<FormElementDto> DeleteFormElementAsync(int id, bool trackChanges);
    }
}
