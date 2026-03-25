using System.ComponentModel.DataAnnotations;

namespace MultiShop.Catalog.Dtos.ProductDetailDtos
{
    public class CreateProductDetailDto
    {
        public string ProductDescription { get; set; }
        public string ProductInfo { get; set; }
        [Required]
        public string ProductId { get; set; } 
    }
}
