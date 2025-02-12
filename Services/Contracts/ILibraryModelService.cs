using Entities.DTOs.LibraryModelDto;

namespace Services.Contracts
{
    public interface ILibraryModelService
    {
        Task<IEnumerable<LibraryModelDto>> GetAllLibraryModelsAsync(bool trackChanges);
        Task<LibraryModelDto> GetLibraryModelByIdAsync(int id, bool trackChanges);
        Task<LibraryModelDto> GetLibraryModelBySlugAsync(string slug, bool trackChanges);
        Task<LibraryModelDto> GetLibraryModelBySiteAsync(string site, bool trackChanges);
        Task<LibraryModelDto> CreateLibraryModelAsync(
            LibraryModelDtoForInsertion libraryModelDtoForInsertion
        );
        Task<LibraryModelDto> UpdateLibraryModelAsync(
            int id,
            LibraryModelDtoForUpdate libraryModelDtoForUpdate,
            bool trackChanges
        );
        Task<LibraryModelDto> DeleteLibraryModelAsync(int id, bool trackChanges);
    }
}
