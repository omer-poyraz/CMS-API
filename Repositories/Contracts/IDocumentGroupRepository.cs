using Entities.Models;

namespace Repositories.Contracts
{
    public interface IDocumentGroupRepository : IRepositoryBase<DocumentGroup>
    {
        Task<IEnumerable<DocumentGroup>> GetAllDocumentGroupsAsync(bool trackChanges);
        Task<DocumentGroup> GetDocumentGroupByIdAsync(int id, bool trackChanges);
        DocumentGroup CreateDocumentGroup(DocumentGroup documentGroup);
        DocumentGroup UpdateDocumentGroup(DocumentGroup documentGroup);
        DocumentGroup DeleteDocumentGroup(DocumentGroup documentGroup);
    }
}
