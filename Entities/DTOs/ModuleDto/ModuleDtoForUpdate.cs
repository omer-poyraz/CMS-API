using Microsoft.AspNetCore.Http;

namespace Entities.DTOs.ModuleDto
{
    public record ModuleDtoForUpdate : ModuleDtoForManipulation
    {
        public int ID { get; init; }
        public ICollection<IFormFile>? file { get; set; } = new List<IFormFile>();
        public DateTime? UpdatedAt { get; init; } = DateTime.UtcNow;
    }
}
