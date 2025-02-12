namespace Entities.DTOs.FormElementDto
{
    public record FormElementDtoForUpdate : FormElementDtoForManipulation
    {
        public int ID { get; init; }
        public DateTime? UpdatedAt { get; init; } = DateTime.UtcNow;
    }
}
