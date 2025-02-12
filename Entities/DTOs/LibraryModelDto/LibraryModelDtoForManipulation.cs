using System.Text.Json;
using Entities.Models;

namespace Entities.DTOs.LibraryModelDto
{
    public abstract record LibraryModelDtoForManipulation
    {
        public string? File { get; set; }
        public string? Slug { get; set; }
        public string? SlugEN { get; set; }
        public string? Site { get; set; }
        public int? Sort { get; set; }
        public string? Title { get; init; }
        public string? TitleEN { get; init; }
        public string? Description { get; init; }
        public string? DescriptionEN { get; init; }
        public string? Content { get; init; }
        public string? ContentEN { get; init; }
        public string? Field1 { get; init; }
        public string? Field1EN { get; init; }
        public string? Field2 { get; init; }
        public string? Field2EN { get; init; }
        public string? Field3 { get; init; }
        public string? Field3EN { get; init; }
        public string? UserId { get; init; }
        public DateTime? Postdate { get; init; }
        public DateTime? Expdate { get; init; }
    }
}
