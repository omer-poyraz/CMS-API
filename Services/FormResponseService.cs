using AutoMapper;
using Entities.DTOs.FormResponseDto;
using Entities.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Repositories.Contracts;
using Repositories.EFCore;
using Services.Contracts;
using Services.Extensions;

namespace Services
{
    public class FormResponseService : IFormResponseService
    {
        private readonly IRepositoryManager _manager;
        private readonly RepositoryContext _context;
        private readonly IMapper _mapper;

        public FormResponseService(
            IRepositoryManager manager,
            IMapper mapper,
            RepositoryContext context
        )
        {
            _manager = manager;
            _mapper = mapper;
            _context = context;
        }

        public async Task<FormResponseDto> CreateFormResponseAsync(
            FormResponseDtoForInsertion formResponseGroupDtoForInsertion
        )
        {
            var formResponseGroup = _mapper.Map<Entities.Models.FormResponse>(
                formResponseGroupDtoForInsertion
            );
            formResponseGroup.Slug = formResponseGroup.Title.ToSeoUrl();
            formResponseGroup.SlugEN = formResponseGroup.TitleEN.ToSeoUrl();
            _manager.FormResponseRepository.CreateFormResponse(formResponseGroup);
            await _manager.SaveAsync();
            return _mapper.Map<FormResponseDto>(formResponseGroup);
        }

        public async Task<FormResponseDto> DeleteFormResponseAsync(int id, bool trackChanges)
        {
            var formResponseGroup = await _manager.FormResponseRepository.GetFormResponseByIdAsync(
                id,
                trackChanges
            );
            _manager.FormResponseRepository.DeleteFormResponse(formResponseGroup);
            await _manager.SaveAsync();
            return _mapper.Map<FormResponseDto>(formResponseGroup);
        }

        public async Task<IEnumerable<FormResponseDto>> GetAllFormResponsesAsync(bool trackChanges)
        {
            var formResponseGroup = await _manager.FormResponseRepository.GetAllFormResponsesAsync(
                trackChanges
            );
            return _mapper.Map<IEnumerable<FormResponseDto>>(formResponseGroup);
        }

        public async Task<FormResponseDto> GetFormResponseByIdAsync(int id, bool trackChanges)
        {
            var formResponseGroup = await _manager.FormResponseRepository.GetFormResponseByIdAsync(
                id,
                trackChanges
            );
            return _mapper.Map<FormResponseDto>(formResponseGroup);
        }

        public async Task<FormResponseDto> GetFormResponseByFormAsync(int formId, bool trackChanges)
        {
            var formResponseGroup =
                await _manager.FormResponseRepository.GetFormResponseByFormAsync(
                    formId,
                    trackChanges
                );
            return _mapper.Map<FormResponseDto>(formResponseGroup);
        }
    }
}
