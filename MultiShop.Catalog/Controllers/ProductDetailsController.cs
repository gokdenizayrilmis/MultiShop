using Microsoft.AspNetCore.Mvc;
using MultiShop.Catalog.Dtos.ProductDetailDtos;
using MultiShop.Catalog.Services.ProductDetailServices;

namespace MultiShop.Catalog.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductDetailsController : Controller
    {
        private readonly IProductDetailService _ProductDetailService;

        public ProductDetailsController(IProductDetailService ProductDetailService)
        {
            _ProductDetailService = ProductDetailService;
        }

        [HttpGet]
        public async Task<IActionResult> ProductDetailList()
        {
            var categories = await _ProductDetailService.GetAllProductDetailAsync();
            return Ok(categories);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetProductDetailById(string id)
        {
            var value = await _ProductDetailService.GetByIdProductDetailAsync(id);
            return Ok(value);
        }

        [HttpPost]
        public async Task<IActionResult> CreateProductDetail([FromBody] CreateProductDetailDto ProductDetailDto)
        {
            if (string.IsNullOrWhiteSpace(ProductDetailDto?.ProductId))
                return BadRequest("ProductId is required in the request body.");

            await _ProductDetailService.CreateProductDetailAsync(ProductDetailDto);
            return Ok("Ürün Detayı Başarıyla Eklendi!");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateProductDetail(UpdateProductDetailDto ProductDetailDto)
        {
            await _ProductDetailService.UpdateProductDetailAsync(ProductDetailDto);
            return Ok("Ürün Detayı Başarıyla Güncellendi!");
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteProductDetail(string id)
        {
            await _ProductDetailService.DeleteProductDetailAsync(id);
            return Ok("Ürün Detayı Başarıyla Silindi!");
        }
    }
}
