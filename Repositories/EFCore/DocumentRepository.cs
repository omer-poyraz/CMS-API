using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Repositories.Contracts;

namespace Repositories.EFCore
{
    public class DocumentRepository : RepositoryBase<Document>, IDocumentRepository
    {
        public DocumentRepository(RepositoryContext context) : base(context)
        {
        }

        public Document CreateDocument(Document document)
        {
            Create(document);
            return document;
        }

        public Document DeleteDocument(Document document)
        {
            Delete(document);
            return document;
        }

        public async Task<IEnumerable<Document>> GetAllDocumentsAsync(bool trackChanges) => await FindAll(trackChanges)
            .OrderBy(s=>s.DocumentID)
            .Include(s=>s.User)
            .Include(s=>s.DocumentGroup)
            .ToListAsync();

        public async Task<IEnumerable<Document>> GetAllDocumentsByGroupAsync(int id, bool trackChanges) => await FindAll(trackChanges)
            .Where(s=>s.DocumentGroupID==id)
            .OrderBy(s=>s.DocumentID)
            .Include(s=>s.User)
            .Include(s=>s.DocumentGroup)
            .ToListAsync();

        public async Task<Document> GetDocumentByIdAsync(int id, bool trackChanges) => await FindByCondition(s => s.DocumentID.Equals(id), trackChanges)
            .Include(s=>s.User)
            .Include(s=>s.DocumentGroup)
            .SingleOrDefaultAsync();

        public Document UpdateDocument(Document document)
        {
            Update(document);
            return document;
        }
    }
}
