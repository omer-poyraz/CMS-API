using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json;

namespace Entities.Models
{
    public class Blog
    {
        public int ID { get; set; }
        public ICollection<string>? files { get; set; }
        public string? Slug { get; set; }
        public string? SlugEN { get; set; }
        public string? Title { get; set; }
        public string? TitleEN { get; set; }
        public string? Description { get; set; }
        public string? DescriptionEN { get; set; }
        public string? Content { get; set; }
        public string? ContentEN { get; set; }
        public string? Field1 { get; set; }
        public string? Field1EN { get; set; }
        public string? Field2 { get; set; }
        public string? Field2EN { get; set; }
        public string? Field3 { get; set; }
        public string? Field3EN { get; set; }
        public string? UserId { get; set; }
        public User? User { get; set; }
        public DateTime? Postdate { get; set; }
        public DateTime? Expdate { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }
}
