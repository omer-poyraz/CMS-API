using Entities.Models;

namespace Repositories.Contracts
{
    public interface IFormElementRepository : IRepositoryBase<FormElement>
    {
        Task<IEnumerable<FormElement>> GetAllFormElementsAsync(bool trackChanges);
        Task<FormElement> GetFormElementByIdAsync(int id, bool trackChanges);
        FormElement CreateFormElement(FormElement formElement);
        FormElement UpdateFormElement(FormElement formElement);
        FormElement DeleteFormElement(FormElement formElement);
    }
}
