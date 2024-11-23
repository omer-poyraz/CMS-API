using AutoMapper;
using Entities.DTOs.ProductDto;
using Entities.Models;
using Repositories.Contracts;
using Services.Contracts;

namespace Services
{
    public class ProductService : IProductService
    {
        private readonly IRepositoryManager _manager;
        private readonly IMapper _mapper;
        public ProductService(IRepositoryManager manager, IMapper mapper)
        {
            _manager = manager;
            _mapper = mapper;
        }

        public async Task<ProductDto> CreateProductAsync(ProductDtoForInsertion productDtoForInsertion)
        {
            var product = _mapper.Map<Product>(productDtoForInsertion);
            _manager.ProductRepository.CreateProduct(product);
            await _manager.SaveAsync();
            return _mapper.Map<ProductDto>(product);
        }

        public async Task<ProductDto> DeleteProductAsync(int id, bool trackChanges)
        {
            var product = await _manager.ProductRepository.GetProductByIdAsync(id, trackChanges);
            _manager.ProductRepository.DeleteProduct(product);
            await _manager.SaveAsync();
            return _mapper.Map<ProductDto>(product);
        }

        public async Task<IEnumerable<ProductDto>> GetAllProductsAsync(bool trackChanges)
        {
            var product = await _manager.ProductRepository.GetAllProductsAsync(trackChanges);
            return _mapper.Map<IEnumerable<ProductDto>>(product);
        }

        public async Task<IEnumerable<ProductDto>> GetAllProductsByGroupAsync(int id, bool trackChanges)
        {
            var product = await _manager.ProductRepository.GetAllProductsByGroupAsync(id, trackChanges);
            return _mapper.Map<IEnumerable<ProductDto>>(product);
        }

        public async Task<ProductDto> GetProductByIdAsync(int id, bool trackChanges)
        {
            var product = await _manager.ProductRepository.GetProductByIdAsync(id, trackChanges);
            return _mapper.Map<ProductDto>(product);
        }

        public async Task<ProductDto> UpdateProductAsync(int id, ProductDtoForUpdate productDtoForUpdate, bool trackChanges)
        {
            var product = await _manager.ProductRepository.GetProductByIdAsync(id, trackChanges);
            product = _mapper.Map<Product>(productDtoForUpdate);
            _manager.ProductRepository.UpdateProduct(product);
            await _manager.SaveAsync();
            return _mapper.Map<ProductDto>(product);
        }
    }
}
