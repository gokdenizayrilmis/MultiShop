using MultiShop.Basket.Dtos;
using MultiShop.Basket.Settings;
using System.Text.Json;

namespace MultiShop.Basket.Services
{
    public class BasketService : IBaskerService
    {
        private readonly RedisService _redisService;

        public BasketService(RedisService redisService)
        {
            _redisService = redisService;
        }

        public async Task DeleteBasket(string userId)
        {
            var status = await _redisService.GetDb().KeyDeleteAsync(userId);

        }

        public async Task<BasketTotalDto?> GetBasket(string userId)
        {
            var existBasket = await _redisService.GetDb().StringGetAsync(userId);
            if (existBasket.IsNullOrEmpty)
                return null;

            try
            {
                return JsonSerializer.Deserialize<BasketTotalDto>((string)existBasket);
            }
            catch (JsonException)
            {
                return null;
            }
        }

        public Task SaveBasket(BasketTotalDto basket)
        {
            throw new NotImplementedException();
        }
    }
}
