namespace Entities.DTOs.FormDto
{
    public record FormDtoForInsertion : FormDtoForManipulation
    {
        public DateTime? CreatedAt { get; init; } = DateTime.UtcNow;
    }
}
