using Entities.DTOs.DocumentDto;

namespace Services.Contracts
{
    public interface IDocumentService
    {
        Task<IEnumerable<DocumentDto>> GetAllDocumentsAsync(bool trackChanges);
        Task<IEnumerable<DocumentDto>> GetAllDocumentsByGroupAsync(int id, bool trackChanges);
        Task<DocumentDto> GetDocumentByIdAsync(int id, bool trackChanges);
        Task<DocumentDto> CreateDocumentAsync(DocumentDtoForInsertion documentDtoForInsertion);
        Task<DocumentDto> UpdateDocumentAsync(int id, DocumentDtoForUpdate documentDtoForUpdate, bool trackChanges);
        Task<DocumentDto> DeleteDocumentAsync(int id, bool trackChanges);
    }
}
