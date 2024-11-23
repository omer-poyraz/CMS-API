namespace Entities.DTOs.FormDto
{
    public record FormDtoForInsertion : FormDtoForManipulation
    {
        public DateTime CreateAt { get; init; }
        public FormDtoForInsertion()
        {
            CreateAt = DateTime.UtcNow;
        }
    }
}
