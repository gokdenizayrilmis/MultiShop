using Microsoft.AspNetCore.Mvc;
using MultiShop.Catalog.Dtos.ProductDtos;
using MultiShop.Catalog.Services.ProductServices;

namespace MultiShop.Catalog.Controllers
{
    public class ProductsController : Controller
    {
        private readonly IProductService _ProductService;

        public ProductsController(IProductService ProductService)
        {
            _ProductService = ProductService;
        }

        [HttpGet]
        public async Task<IActionResult> ProductList()
        {
            var categories = await _ProductService.GetAllProductServiceAsync();
            return Ok(categories);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetProductById(string id)
        {
            var value = await _ProductService.GetByIdProductServiceAsync(id);
            return Ok(value);
        }

        [HttpPost]
        public async Task<IActionResult> CreateProduct(CreateProductDto ProductDto)
        {
            await _ProductService.CreateProductServiceAsync(ProductDto);
            return Ok("Ürün Başarıyla Eklendi!");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateProduct(UpdateProductDto ProductDto)
        {
            await _ProductService.UpdateProductServiceAsync(ProductDto);
            return Ok("Ürün Başarıyla Güncellendi!");
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteProduct(string id)
        {
            await _ProductService.DeleteProductServiceAsync(id);
            return Ok("Ürün Başarıyla Silindi!");
        }
    }
}
