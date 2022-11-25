namespace SalimBlazorECommerce.Server.Services.CartService
{
    public interface ICartService
    {
        Task<ServiceResponse<List<CartProductResponse>>> GetCardProducts(List<CartItem> cartItems);
    }
}
