namespace Entities.DTOs.HeaderDto
{
    public record HeaderDtoForUpdate : HeaderDtoHeaderanipulation
    {
        public int HeaderID { get; init; }
        public DateTime UpdateAt { get; init; }
        public HeaderDtoForUpdate()
        {
            UpdateAt = DateTime.UtcNow;
        }
    }
}
