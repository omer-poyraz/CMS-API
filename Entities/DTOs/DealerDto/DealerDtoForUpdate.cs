namespace Entities.DTOs.DealerDto
{
    public record DealerDtoForUpdate : DealerDtoForManipulation
    {
        public int DealerID { get; init; }
        public DateTime UpdateAt { get; init; }
        public DealerDtoForUpdate()
        {
            UpdateAt = DateTime.UtcNow;
        }
    }
}
