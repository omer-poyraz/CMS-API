namespace Entities.DTOs.ContactDto
{
    public record ContactDtoForUpdate : ContactDtoForManipulation
    {
        public int ContactID { get; init; }
        public DateTime UpdateAt { get; init; }
        public ContactDtoForUpdate()
        {
            UpdateAt = DateTime.UtcNow;
        }
    }
}
