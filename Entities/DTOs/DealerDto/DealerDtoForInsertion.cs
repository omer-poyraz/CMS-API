namespace Entities.DTOs.DealerDto
{
    public record DealerDtoForInsertion : DealerDtoForManipulation
    {
        public DateTime CreateAt { get; init; }
        public DealerDtoForInsertion()
        {
            CreateAt = DateTime.UtcNow;
        }
    }
}
