namespace Entities.DTOs.FormResponseDto
{
    public record FormResponseDtoForUpdate : FormResponseDtoForManipulation
    {
        public int ID { get; init; }
        public DateTime? UpdatedAt { get; init; } = DateTime.UtcNow;
    }
}
