using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Repositories.Contracts;

namespace Repositories.EFCore
{
    public class FormRepository : RepositoryBase<Form>, IFormRepository
    {
        public FormRepository(RepositoryContext context) : base(context)
        {
        }

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

        public async Task<IEnumerable<Form>> GetAllFormsAsync(bool trackChanges) => await FindAll(trackChanges)
            .OrderBy(s=>s.FormID)
            .Include(s=>s.User)
            .ToListAsync();

        public async Task<Form> GetFormByIdAsync(int id, bool trackChanges) => await FindByCondition(s => s.FormID.Equals(id), trackChanges)
            .Include(s=>s.User)
            .SingleOrDefaultAsync();

        public Form UpdateForm(Form form)
        {
            Update(form);
            return form;
        }
    }
}
