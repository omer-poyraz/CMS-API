using AutoMapper;
using Entities.DTOs.ServicesDto;
using Entities.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Repositories.Contracts;
using Repositories.EFCore;
using Services.Contracts;

namespace Services
{
    public class ServicesService : IServicesService
    {
        private readonly IRepositoryManager _manager;
        private readonly RepositoryContext _context;
        private readonly IMapper _mapper;

        public ServicesService(
            IRepositoryManager manager,
            IMapper mapper,
            RepositoryContext context
        )
        {
            _manager = manager;
            _mapper = mapper;
            _context = context;
        }

        public async Task<ServicesDto> CreateServicesAsync(
            ServicesDtoForInsertion servicesGroupDtoForInsertion
        )
        {
            var servicesGroup = _mapper.Map<Entities.Models.Services>(servicesGroupDtoForInsertion);
            _manager.ServicesRepository.CreateServices(servicesGroup);
            await _manager.SaveAsync();
            return _mapper.Map<ServicesDto>(servicesGroup);
        }

        public async Task<ServicesDto> DeleteServicesAsync(int id, bool trackChanges)
        {
            var servicesGroup = await _manager.ServicesRepository.GetServicesByIdAsync(
                id,
                trackChanges
            );
            _manager.ServicesRepository.DeleteServices(servicesGroup);
            await _manager.SaveAsync();
            return _mapper.Map<ServicesDto>(servicesGroup);
        }

        public async Task<IEnumerable<ServicesDto>> GetAllServicesAsync(bool trackChanges)
        {
            var servicesGroup = await _manager.ServicesRepository.GetAllServicesAsync(trackChanges);
            return _mapper.Map<IEnumerable<ServicesDto>>(servicesGroup);
        }

        public async Task<ServicesDto> GetServicesByIdAsync(int id, bool trackChanges)
        {
            var servicesGroup = await _manager.ServicesRepository.GetServicesByIdAsync(
                id,
                trackChanges
            );
            return _mapper.Map<ServicesDto>(servicesGroup);
        }

        public async Task<ServicesDto> UpdateServicesAsync(
            int id,
            ServicesDtoForUpdate servicesGroupDtoForUpdate,
            bool trackChanges
        )
        {
            var servicesGroup = await _manager.ServicesRepository.GetServicesByIdAsync(
                id,
                trackChanges
            );
            servicesGroup = _mapper.Map<Entities.Models.Services>(servicesGroupDtoForUpdate);
            _manager.ServicesRepository.UpdateServices(servicesGroup);
            await _manager.SaveAsync();
            return _mapper.Map<ServicesDto>(servicesGroup);
        }
    }
}
