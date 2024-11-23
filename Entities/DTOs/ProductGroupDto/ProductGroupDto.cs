using Entities.Models;

namespace Entities.DTOs.ProductGroupDto
{
    public record ProductGroupDto
    {
        public int ProductGroupID { get; init; }
        public string? FileName { get; init; }
        public string? FilePath { get; init; }
        public string? FileFullPath { get; init; }
        public string? FileName2 { get; init; }
        public string? FilePath2 { get; init; }
        public string? FileFullPath2 { get; init; }
        public string? FileName3 { get; init; }
        public string? FilePath3 { get; init; }
        public string? FileFullPath3 { get; init; }
        public string? Title { get; init; }
        public string? TitleEN { get; init; }
        public string? Description { get; init; }
        public string? DescriptionEN { get; init; }
        public string? Content { get; init; }
        public string? ContentEN { get; init; }
        public string? AdditionalField1 { get; init; }
        public string? AdditionalField1EN { get; init; }
        public string? AdditionalField2 { get; init; }
        public string? AdditionalField2EN { get; init; }
        public string? AdditionalField3 { get; init; }
        public string? AdditionalField3EN { get; init; }
        public ICollection<Product>? Products { get; init; }
        public Header? Header { get; init; }
        public int? HeaderID { get; init; }
        public DocumentGroup? DocumentGroup { get; init; }
        public int? DocumentGroupID { get; init; }
        public Seo? Seo { get; init; }
        public int? SeoID { get; init; }
        public User? User { get; init; }
        public string? UserId { get; init; }
        public DateTime CreateAt { get; init; }
        public DateTime UpdateAt { get; init; }
    }
}
