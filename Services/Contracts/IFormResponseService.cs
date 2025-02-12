using Entities.DTOs.FormResponseDto;

namespace Services.Contracts
{
    public interface IFormResponseService
    {
        Task<IEnumerable<FormResponseDto>> GetAllFormResponsesAsync(bool trackChanges);
        Task<FormResponseDto> GetFormResponseByIdAsync(int id, bool trackChanges);
        Task<FormResponseDto> GetFormResponseByFormAsync(int formId, bool trackChanges);
        Task<FormResponseDto> CreateFormResponseAsync(
            FormResponseDtoForInsertion formResponseDtoForInsertion
        );
        Task<FormResponseDto> DeleteFormResponseAsync(int id, bool trackChanges);
    }
}
