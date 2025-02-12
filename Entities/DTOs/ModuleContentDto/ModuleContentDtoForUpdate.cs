using Microsoft.AspNetCore.Http;

namespace Entities.DTOs.ModuleContentDto
{
    public record ModuleContentDtoForUpdate : ModuleContentDtoForManipulation
    {
        public int ID { get; init; }
        public ICollection<IFormFile>? file { get; set; }
        public DateTime? UpdatedAt { get; init; } = DateTime.UtcNow;
    }
}
