using Entities.Models;

namespace Entities.DTOs.FilesDto
{
    public record FilesDto
    {
        public int FilesID { get; init; }
        public string? FileName { get; init; }
        public string? FilePath { get; init; }
        public string? FileFullPath { get; init; }
        public string? Field1TR { get; init; }
        public string? Field1EN { get; init; }
        public string? Field1AR { get; init; }
        public string? Field1FR { get; init; }
        public string? Field2TR { get; init; }
        public string? Field2EN { get; init; }
        public string? Field2AR { get; init; }
        public string? Field2FR { get; init; }
        public string? Field3TR { get; init; }
        public string? Field3EN { get; init; }
        public string? Field3AR { get; init; }
        public string? Field3FR { get; init; }
        public string? Field4TR { get; init; }
        public string? Field4EN { get; init; }
        public string? Field4AR { get; init; }
        public string? Field4FR { get; init; }
        public string? Field5TR { get; init; }
        public string? Field5EN { get; init; }
        public string? Field5AR { get; init; }
        public string? Field5FR { get; init; }
        public int Sort { get; init; }
        public FilesGroup? FilesGroup { get; init; }
        public int? FilesGroupID { get; init; }
        public User? User { get; init; }
        public string? UserId { get; init; }
        public DateTime CreateAt { get; init; }
        public DateTime UpdateAt { get; init; }
    }
}
