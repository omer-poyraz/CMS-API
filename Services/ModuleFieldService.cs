using AutoMapper;
using Entities.DTOs.ModuleFieldDto;
using Entities.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Repositories.Contracts;
using Repositories.EFCore;
using Services.Contracts;
using Services.Extensions;

namespace Services
{
    public class ModuleFieldService : IModuleFieldService
    {
        private readonly IRepositoryManager _manager;
        private readonly RepositoryContext _context;
        private readonly IMapper _mapper;

        public ModuleFieldService(
            IRepositoryManager manager,
            IMapper mapper,
            RepositoryContext context
        )
        {
            _manager = manager;
            _mapper = mapper;
            _context = context;
        }

        public async Task<ModuleFieldDto> CreateModuleFieldAsync(
            ModuleFieldDtoForInsertion moduleFieldDtoForInsertion
        )
        {
            var moduleField = _mapper.Map<Entities.Models.ModuleField>(moduleFieldDtoForInsertion);
            _manager.ModuleFieldRepository.CreateModuleField(moduleField);
            await _manager.SaveAsync();
            return _mapper.Map<ModuleFieldDto>(moduleField);
        }

        public async Task<ModuleFieldDto> DeleteModuleFieldAsync(int id, bool trackChanges)
        {
            var moduleField = await _manager.ModuleFieldRepository.GetModuleFieldByIdAsync(
                id,
                trackChanges
            );
            _manager.ModuleFieldRepository.DeleteModuleField(moduleField);
            await _manager.SaveAsync();
            return _mapper.Map<ModuleFieldDto>(moduleField);
        }

        public async Task<IEnumerable<ModuleFieldDto>> GetAllModuleFieldsAsync(bool trackChanges)
        {
            var moduleField = await _manager.ModuleFieldRepository.GetAllModuleFieldsAsync(
                trackChanges
            );
            return _mapper.Map<IEnumerable<ModuleFieldDto>>(moduleField);
        }

        public async Task<ModuleFieldDto> GetModuleFieldByIdAsync(int id, bool trackChanges)
        {
            var moduleField = await _manager.ModuleFieldRepository.GetModuleFieldByIdAsync(
                id,
                trackChanges
            );
            return _mapper.Map<ModuleFieldDto>(moduleField);
        }

        public async Task<ModuleFieldDto> GetModuleFieldBySlugAsync(string slug, bool trackChanges)
        {
            var moduleField = await _manager.ModuleFieldRepository.GetModuleFieldBySlugAsync(
                slug,
                trackChanges
            );
            return _mapper.Map<ModuleFieldDto>(moduleField);
        }

        public async Task<ModuleFieldDto> SortModuleFieldAsync(int id, int sort, bool trackChanges)
        {
            var moduleField = await _manager.ModuleFieldRepository.SortModuleFieldAsync(
                id,
                sort,
                trackChanges
            );
            return _mapper.Map<ModuleFieldDto>(moduleField);
        }

        public async Task<ModuleFieldDto> UpdateModuleFieldAsync(
            int id,
            ModuleFieldDtoForUpdate moduleFieldDtoForUpdate,
            bool trackChanges
        )
        {
            var moduleField = await _manager.ModuleFieldRepository.GetModuleFieldByIdAsync(
                id,
                trackChanges
            );
            var newFiles = new List<string>();
            foreach (var file in moduleField.Files)
            {
                newFiles.Add(file);
            }
            if (moduleFieldDtoForUpdate.Files.Count() > 0)
            {
                foreach (var file in moduleFieldDtoForUpdate.Files)
                {
                    newFiles.Add(file);
                }
            }
            moduleField.Files = newFiles;
            _mapper.Map(moduleFieldDtoForUpdate, moduleField);
            _manager.ModuleFieldRepository.UpdateModuleField(moduleField);
            await _manager.SaveAsync();
            return _mapper.Map<ModuleFieldDto>(moduleField);
        }
    }
}
