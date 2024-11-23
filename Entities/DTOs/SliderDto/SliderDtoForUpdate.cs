namespace Entities.DTOs.SliderDto
{
    public record SliderDtoForUpdate : SliderDtoForManipulation
    {
        public int SliderID { get; init; }
        public DateTime UpdateAt { get; init; }
        public SliderDtoForUpdate()
        {
            UpdateAt = DateTime.UtcNow;
        }
    }
}
