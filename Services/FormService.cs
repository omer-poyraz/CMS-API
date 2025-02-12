using AutoMapper;
using Entities.DTOs.FormDto;
using Entities.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Repositories.Contracts;
using Repositories.EFCore;
using Services.Contracts;
using Services.Extensions;

namespace Services
{
    public class FormService : IFormService
    {
        private readonly IRepositoryManager _manager;
        private readonly RepositoryContext _context;
        private readonly IMapper _mapper;

        public FormService(IRepositoryManager manager, IMapper mapper, RepositoryContext context)
        {
            _manager = manager;
            _mapper = mapper;
            _context = context;
        }

        public async Task<FormDto> CreateFormAsync(FormDtoForInsertion formGroupDtoForInsertion)
        {
            var formGroup = _mapper.Map<Entities.Models.Form>(formGroupDtoForInsertion);
            formGroup.Slug = formGroup.Title.ToSeoUrl();
            formGroup.SlugEN = formGroup.TitleEN.ToSeoUrl();
            _manager.FormRepository.CreateForm(formGroup);
            await _manager.SaveAsync();
            return _mapper.Map<FormDto>(formGroup);
        }

        public async Task<FormDto> DeleteFormAsync(int id, bool trackChanges)
        {
            var formGroup = await _manager.FormRepository.GetFormByIdAsync(id, trackChanges);
            _manager.FormRepository.DeleteForm(formGroup);
            await _manager.SaveAsync();
            return _mapper.Map<FormDto>(formGroup);
        }

        public async Task<IEnumerable<FormDto>> GetAllFormsAsync(bool trackChanges)
        {
            var formGroup = await _manager.FormRepository.GetAllFormsAsync(trackChanges);
            return _mapper.Map<IEnumerable<FormDto>>(formGroup);
        }

        public async Task<FormDto> GetFormByIdAsync(int id, bool trackChanges)
        {
            var formGroup = await _manager.FormRepository.GetFormByIdAsync(id, trackChanges);
            return _mapper.Map<FormDto>(formGroup);
        }

        public async Task<FormDto> GetFormBySlugAsync(string slug, bool trackChanges)
        {
            var formGroup = await _manager.FormRepository.GetFormBySlugAsync(slug, trackChanges);
            return _mapper.Map<FormDto>(formGroup);
        }

        public async Task<FormDto> UpdateFormAsync(
            int id,
            FormDtoForUpdate formGroupDtoForUpdate,
            bool trackChanges
        )
        {
            var formGroup = await _manager.FormRepository.GetFormByIdAsync(id, trackChanges);
            var newFiles = new List<string>();
            foreach (var file in formGroup.files)
            {
                newFiles.Add(file);
            }
            if (formGroupDtoForUpdate.files.Count() > 0)
            {
                foreach (var file in formGroupDtoForUpdate.files)
                {
                    newFiles.Add(file);
                }
            }
            formGroup.files = newFiles;
            formGroup.Slug = formGroupDtoForUpdate.Title.ToSeoUrl();
            formGroup.SlugEN = formGroupDtoForUpdate.TitleEN.ToSeoUrl();
            formGroup = _mapper.Map<Entities.Models.Form>(formGroupDtoForUpdate);
            _manager.FormRepository.UpdateForm(formGroup);
            await _manager.SaveAsync();
            return _mapper.Map<FormDto>(formGroup);
        }
    }
}
