namespace Entities.DTOs.ImageGroupDto
{
    public record ImageGroupDtoForUpdate : ImageGroupDtoForManipulation
    {
        public int ImageGroupID { get; init; }
        public DateTime UpdateAt { get; init; }
        public ImageGroupDtoForUpdate()
        {
            UpdateAt = DateTime.UtcNow;
        }
    }
}
