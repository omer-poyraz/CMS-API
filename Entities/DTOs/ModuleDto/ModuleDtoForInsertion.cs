using Microsoft.AspNetCore.Http;

namespace Entities.DTOs.ModuleDto
{
    public record ModuleDtoForInsertion : ModuleDtoForManipulation
    {
        public ICollection<IFormFile>? file { get; set; } = new List<IFormFile>();
        public DateTime? CreatedAt { get; init; } = DateTime.UtcNow;
    }
}
