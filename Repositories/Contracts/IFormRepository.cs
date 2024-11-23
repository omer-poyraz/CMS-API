using Entities.Models;

namespace Repositories.Contracts
{
    public interface IFormRepository : IRepositoryBase<Form>
    {
        Task<IEnumerable<Form>> GetAllFormsAsync(bool trackChanges);
        Task<Form> GetFormByIdAsync(int id, bool trackChanges);
        Form CreateForm(Form form);
        Form UpdateForm(Form form);
        Form DeleteForm(Form form);
    }
}
