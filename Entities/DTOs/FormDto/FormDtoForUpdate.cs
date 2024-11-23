namespace Entities.DTOs.FormDto
{
    public record FormDtoForUpdate : FormDtoForManipulation
    {
        public int FormID { get; init; }
        public DateTime UpdateAt { get; init; }
        public FormDtoForUpdate()
        {
            UpdateAt = DateTime.UtcNow;
        }
    }
}
