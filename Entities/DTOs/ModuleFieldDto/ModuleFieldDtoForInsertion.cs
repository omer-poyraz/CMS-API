using Microsoft.AspNetCore.Http;

namespace Entities.DTOs.ModuleFieldDto
{
    public record ModuleFieldDtoForInsertion : ModuleFieldDtoForManipulation
    {
        public ICollection<IFormFile>? file { get; set; } = new List<IFormFile>();
        public DateTime? CreatedAt { get; init; } = DateTime.UtcNow;
    }
}
