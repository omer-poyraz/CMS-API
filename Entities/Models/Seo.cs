using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Models
{
    public class Seo
    {
        public int SeoID { get; set; }
        public string? TitleTR { get; set; }
        public string? TitleEN { get; set; }
        public string? TitleAR { get; set; }
        public string? TitleFR { get; set; }
        public string? TitleRU { get; set; }
        public string? DescriptionTR { get; set; }
        public string? DescriptionEN { get; set; }
        public string? DescriptionAR { get; set; }
        public string? DescriptionFR { get; set; }
        public string? DescriptionRU { get; set; }
        public string? KeywordsTR { get; set; }
        public string? KeywordsEN { get; set; }
        public string? KeywordsAR { get; set; }
        public string? KeywordsFR { get; set; }
        public string? KeywordsRU { get; set; }
        public string? AuthorTR { get; set; }
        public string? AuthorEN { get; set; }
        public string? AuthorAR { get; set; }
        public string? AuthorFR { get; set; }
        public string? AuthorRU { get; set; }
        public User? User { get; set; }
        public string? UserId { get; set; }
        public DateTime CreateAt { get; set; }
        public DateTime UpdateAt { get; set; }
    }
}
