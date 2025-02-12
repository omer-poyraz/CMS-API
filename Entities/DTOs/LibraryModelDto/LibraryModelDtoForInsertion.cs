namespace Entities.DTOs.LibraryModelDto
{
    public record LibraryModelDtoForInsertion : LibraryModelDtoForManipulation
    {
        public DateTime? CreatedAt { get; init; } = DateTime.UtcNow;
    }
}
