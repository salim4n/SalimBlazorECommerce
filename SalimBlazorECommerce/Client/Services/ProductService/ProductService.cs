namespace SalimBlazorECommerce.Client.Services.ProductService
{
    public class ProductService : IProductService
    {
        private readonly HttpClient _http;

        public ProductService(HttpClient http)
        {
            _http = http;
        }

        public List<Product> Products { get; set; } = new List<Product>();
        public string Message { get; set; } = "Loading Product";
        public int CurrentPage { get; set; }
        public int PageCount { get; set; }
        public string LastSearchText { get; set; }

        public event Action ProductsChanged;

        public async Task<ServiceResponse<Product>> GetProduct(int productId)
        {
            var result = await _http.GetFromJsonAsync<ServiceResponse<Product>>($"api/product/{productId}");
            return result;
        }

        public async Task GetProducts(string? categoryUrl = null)
        {
            var result = categoryUrl == null ?
                await _http.GetFromJsonAsync<ServiceResponse<List<Product>>>("api/product/featured") :
                await _http.GetFromJsonAsync<ServiceResponse<List<Product>>>($"api/product/category/{categoryUrl}");
            if (result != null && result.Data != null) Products = result.Data; 
            CurrentPage = 1;
            PageCount = 0;

            if (Products.Count == 0) Message = " No Product found";


            ProductsChanged.Invoke();

        }

        public async Task<List<string>> GetProductsSearchSuggestions(string searchtext)
        {
            var result = await _http.GetFromJsonAsync<ServiceResponse<List<string>>>($"api/product/searchsuggestion/{searchtext}");
            return result.Data;
        }

        public async Task SearchProducts(string searchtext, int page)
        {
            LastSearchText = searchtext;
            var result = await _http.GetFromJsonAsync<ServiceResponse<ProductSearchResult>>($"api/product/search/{searchtext}/{page}");
            if (result != null && result.Data != null)
            {
                Products = result.Data.Products;
                CurrentPage = result.Data.CurrentPage;
                PageCount = result.Data.Pages;
            }
            if (Products.Count == 0) Message = "No product found";
            ProductsChanged?.Invoke();
        }
    }
}
