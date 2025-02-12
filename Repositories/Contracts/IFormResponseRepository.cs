using Entities.Models;

namespace Repositories.Contracts
{
    public interface IFormResponseRepository : IRepositoryBase<FormResponse>
    {
        Task<IEnumerable<FormResponse>> GetAllFormResponsesAsync(bool trackChanges);
        Task<FormResponse> GetFormResponseByIdAsync(int id, bool trackChanges);
        Task<FormResponse> GetFormResponseByFormAsync(int formId, bool trackChanges);
        FormResponse CreateFormResponse(FormResponse formResponse);
        FormResponse DeleteFormResponse(FormResponse formResponse);
    }
}
