using Entities.DTOs.ProductDto;

namespace Services.Contracts
{
    public interface IProductService
    {
        Task<IEnumerable<ProductDto>> GetAllProductsAsync(bool trackChanges);
        Task<IEnumerable<ProductDto>> GetAllProductsByGroupAsync(int id, bool trackChanges);
        Task<ProductDto> GetProductByIdAsync(int id, bool trackChanges);
        Task<ProductDto> CreateProductAsync(ProductDtoForInsertion productDtoForInsertion);
        Task<ProductDto> UpdateProductAsync(int id, ProductDtoForUpdate productDtoForUpdate, bool trackChanges);
        Task<ProductDto> DeleteProductAsync(int id, bool trackChanges);
    }
}
