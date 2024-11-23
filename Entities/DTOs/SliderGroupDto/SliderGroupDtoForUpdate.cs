namespace Entities.DTOs.SliderGroupDto
{
    public record SliderGroupDtoForUpdate : SliderGroupDtoForManipulation
    {
        public int SliderGroupID { get; init; }
        public DateTime UpdateAt { get; init; }
        public SliderGroupDtoForUpdate()
        {
            UpdateAt = DateTime.UtcNow;
        }
    }
}
