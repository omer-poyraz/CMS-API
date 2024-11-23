namespace Entities.DTOs.ProductGroupDto
{
    public record ProductGroupDtoForUpdate : ProductGroupDtoForManipulation
    {
        public int ProductGroupID { get; init; }
        public DateTime UpdateAt { get; init; }
        public ProductGroupDtoForUpdate()
        {
            UpdateAt = DateTime.UtcNow;
        }
    }
}
