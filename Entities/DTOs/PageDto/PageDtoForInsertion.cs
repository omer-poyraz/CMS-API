namespace Entities.DTOs.PageDto
{
    public record PageDtoForInsertion : PageDtoForManipulation
    {
        public DateTime CreateAt { get; init; }
        public PageDtoForInsertion()
        {
            CreateAt = DateTime.UtcNow;
        }
    }
}
