using Entities.DTOs.ProductGroupDto;

namespace Services.Contracts
{
    public interface IProductGroupService
    {
        Task<IEnumerable<ProductGroupDto>> GetAllProductGroupsAsync(bool trackChanges);
        Task<ProductGroupDto> GetProductGroupByIdAsync(int id, bool trackChanges);
        Task<ProductGroupDto> GetProductGroupByHeaderIdAsync(int id, bool trackChanges);
        Task<ProductGroupDto> GetProductGroupByHeaderURLAsync(string url, bool trackChanges);
        Task<ProductGroupDto> CreateProductGroupAsync(ProductGroupDtoForInsertion productGroupDtoForInsertion);
        Task<ProductGroupDto> UpdateProductGroupAsync(int id, ProductGroupDtoForUpdate productGroupDtoForUpdate, bool trackChanges);
        Task<ProductGroupDto> DeleteProductGroupAsync(int id, bool trackChanges);
    }
}
