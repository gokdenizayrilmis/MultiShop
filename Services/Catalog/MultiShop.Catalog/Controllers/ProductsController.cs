using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Catalog.Dtos.ProductDtos;
using MultiShop.Catalog.Services.ProductServices;

namespace MultiShop.Catalog.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : Controller
    {
        private readonly IProductService _productService;

        public ProductsController(IProductService ProductService)
        {
            _productService = ProductService;
        }

        [HttpGet]
        public async Task<IActionResult> ProductList()
        {
            var categories = await _productService.GetAllProductServiceAsync();
            return Ok(categories);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetProductById(string id)
        {
            var value = await _productService.GetByIdProductServiceAsync(id);
            return Ok(value);
        }

        [HttpPost]
        public async Task<IActionResult> CreateProduct(CreateProductDto ProductDto)
        {
            await _productService.CreateProductServiceAsync(ProductDto);
            return Ok("Ürün Başarıyla Eklendi!");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateProduct(UpdateProductDto ProductDto)
        {
            await _productService.UpdateProductServiceAsync(ProductDto);
            return Ok("Ürün Başarıyla Güncellendi!");
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteProduct(string id)
        {
            await _productService.DeleteProductServiceAsync(id);
            return Ok("Ürün Başarıyla Silindi!");
        }
    }
}
