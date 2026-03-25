using MultiShop.Catalog.Dtos.ProductDtos;

namespace MultiShop.Catalog.Services.ProductServices
{
    public interface IProductService
    {
        Task<List<ResultProductDto>> GetAllProductServiceAsync();
        Task CreateProductServiceAsync(CreateProductDto ProductDto);
        Task UpdateProductServiceAsync(UpdateProductDto ProductDto);
        Task DeleteProductServiceAsync(string id);
        Task<GetByIdProductDto> GetByIdProductServiceAsync(string id);
    }
}
