namespace MultiShop.Basket.LoginServices
{
    public class LoginService : ILoginService
    {
        private readonly IHttpContextAccessor _httpcontextAccessor;

        public LoginService(IHttpContextAccessor httpContextAccessor)
        {
            _httpcontextAccessor = httpContextAccessor;
        }

        public string? GetUserId =>
            _httpcontextAccessor.HttpContext?.User?.FindFirst("sub")?.Value
            ?? _httpcontextAccessor.HttpContext?.User?.FindFirst("client_id")?.Value;
    }
}
