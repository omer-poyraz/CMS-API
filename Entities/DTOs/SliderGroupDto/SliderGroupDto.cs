using Entities.Models;

namespace Entities.DTOs.SliderGroupDto
{
    public record SliderGroupDto
    {
        public int SliderGroupID { get; init; }
        public string? Title { get; init; }
        public string? TitleEN { get; init; }
        public string? Description { get; init; }
        public string? DescriptionEN { get; init; }
        public string? AdditionalField1 { get; init; }
        public string? AdditionalField1EN { get; init; }
        public string? AdditionalField2 { get; init; }
        public string? AdditionalField2EN { get; init; }
        public string? AdditionalField3 { get; init; }
        public string? AdditionalField3EN { get; init; }
        public ICollection<Slider>? Sliders { get; init; }
        public User? User { get; init; }
        public string? UserId { get; init; }
        public DateTime CreateAt { get; init; }
        public DateTime UpdateAt { get; init; }
    }
}
