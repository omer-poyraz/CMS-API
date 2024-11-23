namespace Entities.DTOs.ProductDto
{
    public abstract record ProductDtoForManipulation
    {
        public string? FileName { get; set; }
        public string? FilePath { get; set; }
        public string? FileFullPath { get; set; }
        public string? Title { get; set; }
        public string? TitleEN { get; set; }
        public string? Description { get; set; }
        public string? DescriptionEN { get; set; }
        public string? URL { get; set; }
        public string? URLEN { get; set; }
        public string? AdditionalField1 { get; set; }
        public string? AdditionalField1EN { get; set; }
        public string? AdditionalField2 { get; set; }
        public string? AdditionalField2EN { get; set; }
        public string? AdditionalField3 { get; set; }
        public string? AdditionalField3EN { get; set; }
        public int? ProductGroupID { get; set; }
        public string? UserId { get; set; }
    }
}
