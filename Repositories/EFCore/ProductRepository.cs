using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Repositories.Contracts;

namespace Repositories.EFCore
{
    public class ProductRepository : RepositoryBase<Product>, IProductRepository
    {
        public ProductRepository(RepositoryContext context) : base(context)
        {
        }

        public Product CreateProduct(Product product)
        {
            Create(product);
            return product;
        }

        public Product DeleteProduct(Product product)
        {
            Delete(product);
            return product;
        }

        public async Task<IEnumerable<Product>> GetAllProductsAsync(bool trackChanges) => await FindAll(trackChanges)
            .OrderBy(s=>s.ProductID)
            .Include(s=>s.User)
            .Include(s=>s.ProductGroup)
            .ToListAsync();

        public async Task<IEnumerable<Product>> GetAllProductsByGroupAsync(int id, bool trackChanges) => await FindAll(trackChanges)
            .Where(s=>s.ProductGroupID == id)
            .OrderBy(s=>s.ProductID)
            .Include(s=>s.User)
            .Include(s=>s.ProductGroup)
            .ToListAsync();

        public async Task<Product> GetProductByIdAsync(int id, bool trackChanges) => await FindByCondition(s => s.ProductID.Equals(id), trackChanges)
            .Include(s=>s.User)
            .Include(s=>s.ProductGroup)
            .SingleOrDefaultAsync();

        public Product UpdateProduct(Product product)
        {
            Update(product);
            return product;
        }
    }
}
