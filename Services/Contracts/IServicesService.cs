using Entities.DTOs.ServicesDto;

namespace Services.Contracts
{
    public interface IServicesService
    {
        Task<IEnumerable<ServicesDto>> GetAllServicesAsync(bool trackChanges);
        Task<ServicesDto> GetServicesByIdAsync(int id, bool trackChanges);
        Task<ServicesDto> CreateServicesAsync(ServicesDtoForInsertion servicesDtoForInsertion);
        Task<ServicesDto> UpdateServicesAsync(
            int id,
            ServicesDtoForUpdate servicesDtoForUpdate,
            bool trackChanges
        );
        Task<ServicesDto> DeleteServicesAsync(int id, bool trackChanges);
    }
}
