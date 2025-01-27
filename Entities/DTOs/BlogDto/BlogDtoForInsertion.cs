namespace Entities.DTOs.BlogDto
{
    public record BlogDtoForInsertion : BlogDtoForManipulation
    {
        public DateTime? CreatedAt { get; init; } = DateTime.UtcNow;
    }
}
