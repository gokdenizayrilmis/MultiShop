using Microsoft.AspNetCore.Mvc;
using MultiShop.Catalog.Dtos.ProductDetailDtos;
using MultiShop.Catalog.Dtos.ProductImageDtos;
using MultiShop.Catalog.Services.ProductDetailServices;
using MultiShop.Catalog.Services.ProductImageServices;

namespace MultiShop.Catalog.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductImagesController : Controller
    {
        private readonly IProductImageService _ProductImageService;

        public ProductImagesController(IProductImageService productImageService)
        {
            _ProductImageService = productImageService;
        }

        [HttpGet]
        public async Task<IActionResult> ProductImageList()
        {
            var categories = await _ProductImageService.GetAllProductImageAsync();
            return Ok(categories);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetProductImageById(string id)
        {
            var value = await _ProductImageService.GetByIdProductImageAsync(id);
            return Ok(value);
        }

        [HttpPost]
        public async Task<IActionResult> CreateProductImage(CreateProductImageDto ProductImageDto)
        {
            await _ProductImageService.CreateProductImageAsync(ProductImageDto);
            return Ok("Ürün Resmi Başarıyla Eklendi!");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateProductImage(UpdateProductImageDto ProductImageDto)
        {
            await _ProductImageService.UpdateProductImageAsync(ProductImageDto);
            return Ok("Ürün Resmi Başarıyla Güncellendi!");
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteProductImage(string id)
        {
            await _ProductImageService.DeleteProductImageAsync(id);
            return Ok("Ürün Resmi Başarıyla Silindi!");
        }
    }
}
