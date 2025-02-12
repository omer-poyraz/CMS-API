using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Repositories.Contracts;

namespace Repositories.EFCore
{
    public class FormResponseRepository : RepositoryBase<FormResponse>, IFormResponseRepository
    {
        public FormResponseRepository(RepositoryContext context)
            : base(context) { }

        public FormResponse CreateFormResponse(FormResponse formResponse)
        {
            Create(formResponse);
            return formResponse;
        }

        public FormResponse DeleteFormResponse(FormResponse formResponse)
        {
            Delete(formResponse);
            return formResponse;
        }

        public async Task<IEnumerable<FormResponse>> GetAllFormResponsesAsync(bool trackChanges) =>
            await FindAll(trackChanges)
                .OrderBy(s => s.ID)
                .Include(s => s.User)
                .Include(s => s.Form)
                .ToListAsync();

        public async Task<FormResponse> GetFormResponseByIdAsync(int id, bool trackChanges) =>
            await FindByCondition(s => s.ID.Equals(id), trackChanges)
                .Include(s => s.User)
                .Include(s => s.Form)
                .SingleOrDefaultAsync();

        public async Task<FormResponse> GetFormResponseByFormAsync(int formId, bool trackChanges) =>
            await FindByCondition(s => s.Form.ID.Equals(formId), trackChanges)
                .Include(s => s.User)
                .Include(s => s.Form)
                .SingleOrDefaultAsync();

        public async Task<FormResponse> GetFormResponseBySlugAsync(
            string slug,
            bool trackChanges
        ) =>
            await FindByCondition(s => s.Slug.Equals(slug) || s.SlugEN.Equals(slug), trackChanges)
                .Include(s => s.User)
                .SingleOrDefaultAsync();
    }
}
