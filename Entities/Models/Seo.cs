using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Models
{
    public class Seo
    {
        public int SeoID { get; set; }
        public string? Title { get; set; }
        public string? TitleEN { get; set; }
        public string? Description { get; set; }
        public string? DescriptionEN { get; set; }
        public string? Keywords { get; set; }
        public string? KeywordsEN { get; set; }
        public string? Author { get; set; }
        public string? AuthorEN { get; set; }
        public User? User { get; set; }
        public string? UserId { get; set; }
        public DateTime CreateAt { get; set; }
        public DateTime UpdateAt { get; set; }
    }
}
