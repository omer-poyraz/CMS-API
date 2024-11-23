namespace Entities.DTOs.SettingDto
{
    public record SettingDtoForInsertion : SettingDtoForManipulation
    {
        public DateTime CreateAt { get; set; }
        public SettingDtoForInsertion()
        {
            CreateAt = DateTime.UtcNow;
        }
    }
}
