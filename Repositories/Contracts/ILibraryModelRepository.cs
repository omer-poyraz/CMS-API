using Entities.Models;

namespace Repositories.Contracts
{
    public interface ILibraryModelRepository : IRepositoryBase<LibraryModel>
    {
        Task<IEnumerable<LibraryModel>> GetAllLibraryModelsAsync(bool trackChanges);
        Task<LibraryModel> GetLibraryModelByIdAsync(int id, bool trackChanges);
        Task<LibraryModel> GetLibraryModelBySlugAsync(string slug, bool trackChanges);
        Task<LibraryModel> GetLibraryModelBySiteAsync(string site, bool trackChanges);
        LibraryModel CreateLibraryModel(LibraryModel libraryModel);
        LibraryModel UpdateLibraryModel(LibraryModel libraryModel);
        LibraryModel DeleteLibraryModel(LibraryModel libraryModel);
    }
}
