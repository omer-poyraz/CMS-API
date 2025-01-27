namespace Entities.DTOs.BlogDto
{
    public record BlogDtoForUpdate : BlogDtoForManipulation
    {
        public int ID { get; init; }
        public DateTime? UpdatedAt { get; init; } = DateTime.UtcNow;
    }
}
