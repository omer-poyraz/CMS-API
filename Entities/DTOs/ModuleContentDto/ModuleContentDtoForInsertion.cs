using Microsoft.AspNetCore.Http;

namespace Entities.DTOs.ModuleContentDto
{
    public record ModuleContentDtoForInsertion : ModuleContentDtoForManipulation
    {
        public ICollection<IFormFile>? file { get; set; }
        public DateTime? CreatedAt { get; init; } = DateTime.UtcNow;
    }
}
