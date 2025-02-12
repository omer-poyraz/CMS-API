namespace Entities.DTOs.FormElementDto
{
    public record FormElementDtoForInsertion : FormElementDtoForManipulation
    {
        public DateTime? CreatedAt { get; init; } = DateTime.UtcNow;
    }
}
