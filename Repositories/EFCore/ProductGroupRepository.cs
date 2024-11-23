using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Repositories.Contracts;

namespace Repositories.EFCore
{
    public class ProductGroupRepository : RepositoryBase<ProductGroup>, IProductGroupRepository
    {
        public ProductGroupRepository(RepositoryContext context)
            : base(context) { }

        public ProductGroup CreateProductGroup(ProductGroup productGroup)
        {
            Create(productGroup);
            return productGroup;
        }

        public ProductGroup DeleteProductGroup(ProductGroup productGroup)
        {
            Delete(productGroup);
            return productGroup;
        }

        public async Task<IEnumerable<ProductGroup>> GetAllProductGroupsAsync(bool trackChanges) =>
            await FindAll(trackChanges)
                .OrderBy(s => s.ProductGroupID)
                .Include(s => s.User)
                .Include(s => s.Products)
                .Include(s => s.Seo)
                .Include(s => s.Header)
                .Include(s => s.DocumentGroup)
                .ToListAsync();

        public async Task<ProductGroup> GetProductGroupByIdAsync(int id, bool trackChanges) =>
            await FindByCondition(s => s.ProductGroupID.Equals(id), trackChanges)
                .Include(s => s.User)
                .Include(s => s.Products)
                .Include(s => s.Seo)
                .Include(s => s.Header)
                .Include(s => s.DocumentGroup)
                .SingleOrDefaultAsync();

        public async Task<ProductGroup> GetProductGroupByHeaderIdAsync(int id, bool trackChanges) =>
            await FindByCondition(s => s.HeaderID.Equals(id), trackChanges)
                .Include(s => s.User)
                .Include(s => s.Products)
                .Include(s => s.Seo)
                .Include(s => s.Header)
                .Include(s => s.DocumentGroup)
                .SingleOrDefaultAsync();

        public async Task<ProductGroup> GetProductGroupByHeaderURLAsync(
            string url,
            bool trackChanges
        ) =>
            await FindByCondition(
                    s =>
                        (
                            s.Header.UrlTR.Contains(url)
                            || s.Header.UrlEN.Contains(url)
                            || s.Header.UrlAR.Contains(url)
                            || s.Header.UrlFR.Contains(url)
                        ),
                    trackChanges
                )
                .Include(s => s.User)
                .Include(s => s.Products)
                .Include(s => s.Seo)
                .Include(s => s.Header)
                .Include(s => s.DocumentGroup)
                .SingleOrDefaultAsync();

        public ProductGroup UpdateProductGroup(ProductGroup productGroup)
        {
            Update(productGroup);
            return productGroup;
        }
    }
}
