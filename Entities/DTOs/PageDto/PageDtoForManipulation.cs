namespace Entities.DTOs.PageDto
{
    public abstract record PageDtoForManipulation
    {
        public string? FileName { get; set; }
        public string? FilePath { get; set; }
        public string? FileFullPath { get; set; }
        public string? Title { get; set; }
        public string? TitleEN { get; set; }
        public string? Description { get; set; }
        public string? DescriptionEN { get; set; }
        public string? Content { get; set; }
        public string? ContentEN { get; set; }
        public int? HeaderID { get; set; }
        public int? DocumentGroupID { get; set; }
        public int? SeoID { get; set; }
        public string? UserId { get; set; }
    }
}
