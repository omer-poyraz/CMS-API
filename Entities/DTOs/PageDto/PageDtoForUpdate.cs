namespace Entities.DTOs.PageDto
{
    public record PageDtoForUpdate : PageDtoForManipulation
    {
        public int PageID { get; init; }
        public DateTime UpdateAt { get; init; }
        public PageDtoForUpdate()
        {
            UpdateAt = DateTime.UtcNow;
        }
    }
}
