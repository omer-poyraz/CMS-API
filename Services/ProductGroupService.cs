using AutoMapper;
using Entities.DTOs.ProductGroupDto;
using Entities.Models;
using Repositories.Contracts;
using Services.Contracts;

namespace Services
{
    public class ProductGroupService : IProductGroupService
    {
        private readonly IRepositoryManager _manager;
        private readonly IMapper _mapper;
        public ProductGroupService(IRepositoryManager manager, IMapper mapper)
        {
            _manager = manager;
            _mapper = mapper;
        }

        public async Task<ProductGroupDto> CreateProductGroupAsync(ProductGroupDtoForInsertion productGroupDtoForInsertion)
        {
            var productGroup = _mapper.Map<ProductGroup>(productGroupDtoForInsertion);
            _manager.ProductGroupRepository.CreateProductGroup(productGroup);
            await _manager.SaveAsync();
            return _mapper.Map<ProductGroupDto>(productGroup);
        }

        public async Task<ProductGroupDto> DeleteProductGroupAsync(int id, bool trackChanges)
        {
            var productGroup = await _manager.ProductGroupRepository.GetProductGroupByIdAsync(id, trackChanges);
            _manager.ProductGroupRepository.DeleteProductGroup(productGroup);
            await _manager.SaveAsync();
            return _mapper.Map<ProductGroupDto>(productGroup);
        }

        public async Task<IEnumerable<ProductGroupDto>> GetAllProductGroupsAsync(bool trackChanges)
        {
            var productGroup = await _manager.ProductGroupRepository.GetAllProductGroupsAsync(trackChanges);
            return _mapper.Map<IEnumerable<ProductGroupDto>>(productGroup);
        }

        public async Task<ProductGroupDto> GetProductGroupByIdAsync(int id, bool trackChanges)
        {
            var productGroup = await _manager.ProductGroupRepository.GetProductGroupByIdAsync(id, trackChanges);
            return _mapper.Map<ProductGroupDto>(productGroup);
        }

        public async Task<ProductGroupDto> GetProductGroupByHeaderIdAsync(int id, bool trackChanges)
        {
            var productGroup = await _manager.ProductGroupRepository.GetProductGroupByHeaderIdAsync(id, trackChanges);
            return _mapper.Map<ProductGroupDto>(productGroup);
        }

        public async Task<ProductGroupDto> GetProductGroupByHeaderURLAsync(string url, bool trackChanges)
        {
            var productGroup = await _manager.ProductGroupRepository.GetProductGroupByHeaderURLAsync(url, trackChanges);
            return _mapper.Map<ProductGroupDto>(productGroup);
        }

        public async Task<ProductGroupDto> UpdateProductGroupAsync(int id, ProductGroupDtoForUpdate productGroupDtoForUpdate, bool trackChanges)
        {
            var productGroup = await _manager.ProductGroupRepository.GetProductGroupByIdAsync(id, trackChanges);
            productGroup = _mapper.Map<ProductGroup>(productGroupDtoForUpdate);
            _manager.ProductGroupRepository.UpdateProductGroup(productGroup);
            await _manager.SaveAsync();
            return _mapper.Map<ProductGroupDto>(productGroup);
        }
    }
}
