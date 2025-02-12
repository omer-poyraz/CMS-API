using System.Text.Json;
using Entities.Models;

namespace Entities.DTOs.FormElementDto
{
    public class FormElementDto
    {
        public int ID { get; init; }
        public ICollection<string>? files { get; init; }
        public string? Slug { get; init; }
        public string? SlugEN { get; init; }
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
        public User? User { get; init; }
        public string? Type { get; init; }
        public Form? Form { get; init; }
        public int? FormId { get; init; }
        public DateTime? Postdate { get; init; }
        public DateTime? Expdate { get; init; }
        public DateTime? CreatedAt { get; init; }
        public DateTime? UpdatedAt { get; init; }
    }
}
