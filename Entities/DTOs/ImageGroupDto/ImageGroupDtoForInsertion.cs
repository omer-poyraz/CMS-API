namespace Entities.DTOs.ImageGroupDto
{
    public record ImageGroupDtoForInsertion : ImageGroupDtoForManipulation
    {
        public DateTime CreateAt { get; init; }
        public ImageGroupDtoForInsertion()
        {
            CreateAt = DateTime.UtcNow;
        }
    }
}
