using AutoMapper;
using Entities.DTOs.FormElementDto;
using Entities.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Repositories.Contracts;
using Repositories.EFCore;
using Services.Contracts;
using Services.Extensions;

namespace Services
{
    public class FormElementService : IFormElementService
    {
        private readonly IRepositoryManager _manager;
        private readonly RepositoryContext _context;
        private readonly IMapper _mapper;

        public FormElementService(
            IRepositoryManager manager,
            IMapper mapper,
            RepositoryContext context
        )
        {
            _manager = manager;
            _mapper = mapper;
            _context = context;
        }

        public async Task<FormElementDto> CreateFormElementAsync(
            FormElementDtoForInsertion formElementGroupDtoForInsertion
        )
        {
            var formElementGroup = _mapper.Map<Entities.Models.FormElement>(
                formElementGroupDtoForInsertion
            );
            formElementGroup.Slug = formElementGroup.Title.ToSeoUrl();
            formElementGroup.SlugEN = formElementGroup.TitleEN.ToSeoUrl();
            _manager.FormElementRepository.CreateFormElement(formElementGroup);
            await _manager.SaveAsync();
            return _mapper.Map<FormElementDto>(formElementGroup);
        }

        public async Task<FormElementDto> DeleteFormElementAsync(int id, bool trackChanges)
        {
            var formElementGroup = await _manager.FormElementRepository.GetFormElementByIdAsync(
                id,
                trackChanges
            );
            _manager.FormElementRepository.DeleteFormElement(formElementGroup);
            await _manager.SaveAsync();
            return _mapper.Map<FormElementDto>(formElementGroup);
        }

        public async Task<IEnumerable<FormElementDto>> GetAllFormElementsAsync(bool trackChanges)
        {
            var formElementGroup = await _manager.FormElementRepository.GetAllFormElementsAsync(
                trackChanges
            );
            return _mapper.Map<IEnumerable<FormElementDto>>(formElementGroup);
        }

        public async Task<FormElementDto> GetFormElementByIdAsync(int id, bool trackChanges)
        {
            var formElementGroup = await _manager.FormElementRepository.GetFormElementByIdAsync(
                id,
                trackChanges
            );
            return _mapper.Map<FormElementDto>(formElementGroup);
        }

        public async Task<FormElementDto> UpdateFormElementAsync(
            int id,
            FormElementDtoForUpdate formElementGroupDtoForUpdate,
            bool trackChanges
        )
        {
            var formElementGroup = await _manager.FormElementRepository.GetFormElementByIdAsync(
                id,
                trackChanges
            );
            var newFiles = new List<string>();
            foreach (var file in formElementGroup.files)
            {
                newFiles.Add(file);
            }
            if (formElementGroupDtoForUpdate.files.Count() > 0)
            {
                foreach (var file in formElementGroupDtoForUpdate.files)
                {
                    newFiles.Add(file);
                }
            }
            formElementGroup.files = newFiles;
            formElementGroup.Slug = formElementGroupDtoForUpdate.Title.ToSeoUrl();
            formElementGroup.SlugEN = formElementGroupDtoForUpdate.TitleEN.ToSeoUrl();
            formElementGroup = _mapper.Map<Entities.Models.FormElement>(
                formElementGroupDtoForUpdate
            );
            _manager.FormElementRepository.UpdateFormElement(formElementGroup);
            await _manager.SaveAsync();
            return _mapper.Map<FormElementDto>(formElementGroup);
        }
    }
}
