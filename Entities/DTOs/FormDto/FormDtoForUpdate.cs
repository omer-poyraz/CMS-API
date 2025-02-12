namespace Entities.DTOs.FormDto
{
    public record FormDtoForUpdate : FormDtoForManipulation
    {
        public int ID { get; init; }
        public DateTime? UpdatedAt { get; init; } = DateTime.UtcNow;
    }
}
