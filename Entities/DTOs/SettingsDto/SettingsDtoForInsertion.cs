using Microsoft.AspNetCore.Http;

namespace Entities.DTOs.SettingsDto
{
    public record SettingsDtoForInsertion : SettingsDtoForManipulation
    {
        public ICollection<IFormFile>? file { get; set; } = new List<IFormFile>();
        public DateTime? CreatedAt { get; init; } = DateTime.UtcNow;
    }
}
