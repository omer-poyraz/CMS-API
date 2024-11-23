using Entities.Models;

namespace Repositories.Contracts
{
    public interface IProductGroupRepository : IRepositoryBase<ProductGroup>
    {
        Task<IEnumerable<ProductGroup>> GetAllProductGroupsAsync(bool trackChanges);
        Task<ProductGroup> GetProductGroupByIdAsync(int id, bool trackChanges);
        Task<ProductGroup> GetProductGroupByHeaderIdAsync(int id, bool trackChanges);
        Task<ProductGroup> GetProductGroupByHeaderURLAsync(string url, bool trackChanges);
        ProductGroup CreateProductGroup(ProductGroup productGroup);
        ProductGroup UpdateProductGroup(ProductGroup productGroup);
        ProductGroup DeleteProductGroup(ProductGroup productGroup);
    }
}
