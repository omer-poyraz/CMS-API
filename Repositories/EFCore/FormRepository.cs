using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Repositories.Contracts;

namespace Repositories.EFCore
{
    public class FormRepository : RepositoryBase<Form>, IFormRepository
    {
        public FormRepository(RepositoryContext context)
            : base(context) { }

        public Form CreateForm(Form form)
        {
            Create(form);
            return form;
        }

        public Form DeleteForm(Form form)
        {
            Delete(form);
            return form;
        }

        public async Task<IEnumerable<Form>> GetAllFormsAsync(bool trackChanges) =>
            await FindAll(trackChanges).OrderBy(s => s.ID).Include(s => s.User).ToListAsync();

        public async Task<Form> GetFormByIdAsync(int id, bool trackChanges) =>
            await FindByCondition(s => s.ID.Equals(id), trackChanges)
                .Include(s => s.User)
                .SingleOrDefaultAsync();

        public async Task<Form> GetFormBySlugAsync(string slug, bool trackChanges) =>
            await FindByCondition(s => s.Slug.Equals(slug) || s.SlugEN.Equals(slug), trackChanges)
                .Include(s => s.User)
                .SingleOrDefaultAsync();

        public Form UpdateForm(Form form)
        {
            Update(form);
            return form;
        }
    }
}
