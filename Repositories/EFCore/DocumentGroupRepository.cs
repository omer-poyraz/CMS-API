using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Repositories.Contracts;

namespace Repositories.EFCore
{
    public class DocumentGroupRepository : RepositoryBase<DocumentGroup>, IDocumentGroupRepository
    {
        public DocumentGroupRepository(RepositoryContext context) : base(context)
        {
        }

        public DocumentGroup CreateDocumentGroup(DocumentGroup documentGroup)
        {
            Create(documentGroup);
            return documentGroup;
        }

        public DocumentGroup DeleteDocumentGroup(DocumentGroup documentGroup)
        {
            Delete(documentGroup);
            return documentGroup;
        }

        public async Task<IEnumerable<DocumentGroup>> GetAllDocumentGroupsAsync(bool trackChanges) => await FindAll(trackChanges)
            .OrderBy(s=>s.DocumentGroupID)
            .Include(s=>s.User)
            .Include(s=>s.Documents)
            .ToListAsync();

        public async Task<DocumentGroup> GetDocumentGroupByIdAsync(int id, bool trackChanges) => await FindByCondition(s => s.DocumentGroupID.Equals(id), trackChanges)
            .Include(s=>s.User)
            .Include(s=>s.Documents)
            .SingleOrDefaultAsync();

        public DocumentGroup UpdateDocumentGroup(DocumentGroup documentGroup)
        {
            Update(documentGroup);
            return documentGroup;
        }
    }
}
