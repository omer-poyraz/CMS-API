namespace Entities.DTOs.SettingDto
{
    public record SettingDtoForUpdate : SettingDtoForManipulation
    {
        public int SettingID { get; set; }
        public DateTime UpdateAt { get; set; }
        public SettingDtoForUpdate()
        {
            UpdateAt = DateTime.UtcNow;
        }
    }
}
