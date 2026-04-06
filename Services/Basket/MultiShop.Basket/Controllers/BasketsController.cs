using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Basket.Dtos;
using MultiShop.Basket.LoginServices;
using MultiShop.Basket.Services;

namespace MultiShop.Basket.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BasketsController : ControllerBase
    {
        private readonly ILoginService _loginService;
        private readonly IBasketService _basketService;

        public BasketsController(ILoginService loginService, IBasketService basketService)
        {
            _loginService = loginService;
            _basketService = basketService;
        }


        [HttpGet]
        public async Task<IActionResult> GetMyBasketDetail()
        {
            var userId = _loginService.GetUserId;
            if (string.IsNullOrWhiteSpace(userId))
                return Unauthorized();

            var values = await _basketService.GetBasket(userId);
            return Ok(values);
        }

        [HttpPost]
        public async Task<IActionResult> SaveMyBasket(BasketTotalDto basketTotalDto)
        {
            var userId = _loginService.GetUserId;
            if (string.IsNullOrWhiteSpace(userId))
                return Unauthorized();

            basketTotalDto.UserId = userId;
            await _basketService.SaveBasket(basketTotalDto);
            return Ok(basketTotalDto);
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteMyBasket()
        {
            var userId = _loginService.GetUserId;
            if (string.IsNullOrWhiteSpace(userId))
                return Unauthorized();

            await _basketService.DeleteBasket(userId);
            return Ok("Sepet Başarıyla Silindi!");

        }
    }
}