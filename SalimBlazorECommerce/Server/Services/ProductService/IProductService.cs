namespace SalimBlazorECommerce.Server.Services.ProductService
{
    public interface IProductService
    {
        Task<ServiceResponse<List<Product>>> GetProductsAsync();
        Task<ServiceResponse<Product>> GetProductAsync(int productId);
        Task<ServiceResponse<List<Product>>> GetProductsByCategory(string categoryUrl);
        Task<ServiceResponse<List<Product>>> SearchProducts(string searchtext);
        Task<ServiceResponse<List<string>>> GetProductSearchSuggestion(string searchtext);
        Task<ServiceResponse<List<Product>>> GetFeaturedProducts();
    }
}
