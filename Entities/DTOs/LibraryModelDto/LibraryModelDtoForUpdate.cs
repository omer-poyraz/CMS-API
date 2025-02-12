namespace Entities.DTOs.LibraryModelDto
{
    public record LibraryModelDtoForUpdate : LibraryModelDtoForManipulation
    {
        public int ID { get; init; }
        public DateTime? UpdatedAt { get; init; } = DateTime.UtcNow;
    }
}
