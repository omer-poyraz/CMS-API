namespace Entities.DTOs.ProductGroupDto
{
    public abstract record ProductGroupDtoForManipulation
    {
        public string? FileName { get; set; }
        public string? FilePath { get; set; }
        public string? FileFullPath { get; set; }
        public string? FileName2 { get; set; }
        public string? FilePath2 { get; set; }
        public string? FileFullPath2 { get; set; }
        public string? FileName3 { get; set; }
        public string? FilePath3 { get; set; }
        public string? FileFullPath3 { get; set; }
        public string? Title { get; set; }
        public string? TitleEN { get; set; }
        public string? Description { get; set; }
        public string? DescriptionEN { get; set; }
        public string? Content { get; set; }
        public string? ContentEN { get; set; }
        public string? AdditionalField1 { get; set; }
        public string? AdditionalField1EN { get; set; }
        public string? AdditionalField2 { get; set; }
        public string? AdditionalField2EN { get; set; }
        public string? AdditionalField3 { get; set; }
        public string? AdditionalField3EN { get; set; }
        public int? DocumentGroupID { get; set; }
        public int? HeaderID { get; set; }
        public int? SeoID { get; set; }
        public string? UserId { get; set; }
    }
}
