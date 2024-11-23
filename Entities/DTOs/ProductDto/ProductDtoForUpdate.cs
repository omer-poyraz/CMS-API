namespace Entities.DTOs.ProductDto
{
    public record ProductDtoForUpdate : ProductDtoForManipulation
    {
        public int ProductID { get; init; }
        public DateTime UpdateAt { get; init; }
        public ProductDtoForUpdate()
        {
            UpdateAt = DateTime.UtcNow;
        }
    }
}
