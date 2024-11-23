namespace Entities.DTOs.SliderGroupDto
{
    public record SliderGroupDtoForInsertion : SliderGroupDtoForManipulation
    {
        public DateTime CreateAt { get; init; }
        public SliderGroupDtoForInsertion()
        {
            CreateAt = DateTime.UtcNow;
        }
    }
}
