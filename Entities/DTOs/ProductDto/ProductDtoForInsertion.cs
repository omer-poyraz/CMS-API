namespace Entities.DTOs.ProductDto
{
    public record ProductDtoForInsertion : ProductDtoForManipulation
    {
        public DateTime CreateAt { get; init; }
        public ProductDtoForInsertion()
        {
            CreateAt = DateTime.UtcNow;
        }
    }
}
