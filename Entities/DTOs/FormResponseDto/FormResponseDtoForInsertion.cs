namespace Entities.DTOs.FormResponseDto
{
    public record FormResponseDtoForInsertion : FormResponseDtoForManipulation
    {
        public DateTime? CreatedAt { get; init; } = DateTime.UtcNow;
    }
}
