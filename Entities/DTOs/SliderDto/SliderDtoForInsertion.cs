namespace Entities.DTOs.SliderDto
{
    public record SliderDtoForInsertion : SliderDtoForManipulation
    {
        public DateTime CreateAt { get; init; }
        public SliderDtoForInsertion()
        {
            CreateAt = DateTime.UtcNow;
        }
    }
}
