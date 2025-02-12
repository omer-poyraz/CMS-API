using Microsoft.AspNetCore.Http;

namespace Entities.DTOs.ModuleContentDto
{
    public record ModuleContentDtoForInsertion : ModuleContentDtoForManipulation
    {
        public ICollection<IFormFile>? file { get; set; } = new List<IFormFile>();
        public DateTime? CreatedAt { get; init; } = DateTime.UtcNow;
    }
}
