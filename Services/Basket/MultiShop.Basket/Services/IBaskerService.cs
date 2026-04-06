using MultiShop.Basket.Dtos;

namespace MultiShop.Basket.Services
{
    public interface IBaskerService
    {
        Task<BasketTotalDto> GetBasket(string userId);
        Task SaveBasket(BasketTotalDto basket);
        Task DeleteBasket(string userId);
    }
}
