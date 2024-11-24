namespace Entities.DTOs.SeoDto
{
    public abstract record SeoDtoForManipulation
    {
        public string? TitleTR { get; init; }
        public string? TitleEN { get; init; }
        public string? TitleAR { get; init; }
        public string? TitleFR { get; init; }
        public string? TitleRU { get; init; }
        public string? DescriptionTR { get; init; }
        public string? DescriptionEN { get; init; }
        public string? DescriptionAR { get; init; }
        public string? DescriptionFR { get; init; }
        public string? DescriptionRU { get; init; }
        public string? KeywordsTR { get; init; }
        public string? KeywordsEN { get; init; }
        public string? KeywordsAR { get; init; }
        public string? KeywordsFR { get; init; }
        public string? KeywordsRU { get; init; }
        public string? AuthorTR { get; init; }
        public string? AuthorEN { get; init; }
        public string? AuthorAR { get; init; }
        public string? AuthorFR { get; init; }
        public string? AuthorRU { get; init; }
        public string? UserId { get; init; }
    }
}
