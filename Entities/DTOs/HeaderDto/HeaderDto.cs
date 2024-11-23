using Entities.Models;

namespace Entities.DTOs.HeaderDto
{
    public record HeaderDto
    {
        public int HeaderID { get; set; }
        public string? FileName { get; set; }
        public string? FilePath { get; set; }
        public string? FileFullPath { get; set; }
        public string? TitleTR { get; set; }
        public string? TitleEN { get; set; }
        public string? TitleAR { get; set; }
        public string? TitleFR { get; set; }
        public string? LongTitleTR { get; set; }
        public string? LongTitleEN { get; set; }
        public string? LongTitleAR { get; set; }
        public string? LongTitleFR { get; set; }
        public string? UrlTR { get; set; }
        public string? UrlEN { get; set; }
        public string? UrlAR { get; set; }
        public string? UrlFR { get; set; }
        public int Sort { get; set; }
        public ICollection<Header>? SubHeaders { get; set; } = new List<Header>();
        public int? ParentHeaderID { get; set; }
        public User? User { get; set; }
        public string? UserId { get; set; }
        public DateTime CreateAt { get; set; }
        public DateTime UpdateAt { get; set; }
    }
}
