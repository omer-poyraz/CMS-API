using Entities.DTOs.DocumentGroupDto;

namespace Services.Contracts
{
    public interface IDocumentGroupService
    {
        Task<IEnumerable<DocumentGroupDto>> GetAllDocumentGroupsAsync(bool trackChanges);
        Task<DocumentGroupDto> GetDocumentGroupByIdAsync(int id, bool trackChanges);
        Task<DocumentGroupDto> CreateDocumentGroupAsync(DocumentGroupDtoForInsertion documentGroupDtoForInsertion);
        Task<DocumentGroupDto> UpdateDocumentGroupAsync(int id, DocumentGroupDtoForUpdate documentGroupDtoForUpdate, bool trackChanges);
        Task<DocumentGroupDto> DeleteDocumentGroupAsync(int id, bool trackChanges);
    }
}
