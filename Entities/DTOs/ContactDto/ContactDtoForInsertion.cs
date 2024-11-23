namespace Entities.DTOs.ContactDto
{
    public record ContactDtoForInsertion : ContactDtoForManipulation
    {
        public DateTime CreateAt { get; init; }
        public ContactDtoForInsertion()
        {
            CreateAt = DateTime.UtcNow;
        }
    }
}
