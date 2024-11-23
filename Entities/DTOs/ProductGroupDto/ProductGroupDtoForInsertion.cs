namespace Entities.DTOs.ProductGroupDto
{
    public record ProductGroupDtoForInsertion : ProductGroupDtoForManipulation
    {
        public DateTime CreateAt { get; init; }
        public ProductGroupDtoForInsertion()
        {
            CreateAt = DateTime.UtcNow;
        }
    }
}
