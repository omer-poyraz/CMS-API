using Entities.Models;

namespace Repositories.Contracts
{
    public interface IDocumentRepository : IRepositoryBase<Document>
    {
        Task<IEnumerable<Document>> GetAllDocumentsAsync(bool trackChanges);
        Task<IEnumerable<Document>> GetAllDocumentsByGroupAsync(int id, bool trackChanges);
        Task<Document> GetDocumentByIdAsync(int id, bool trackChanges);
        Document CreateDocument(Document document);
        Document UpdateDocument(Document document);
        Document DeleteDocument(Document document);
    }
}
