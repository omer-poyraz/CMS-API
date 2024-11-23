namespace Entities.DTOs.HeaderDto
{
    public record HeaderDtoForInsertion : HeaderDtoHeaderanipulation
    {
        public DateTime CreateAt { get; init; }
        public HeaderDtoForInsertion()
        {
            CreateAt = DateTime.UtcNow;
        }
    }
}
