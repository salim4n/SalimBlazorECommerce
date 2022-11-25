using Microsoft.AspNetCore.Mvc;

namespace SalimBlazorECommerce.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        public async Task<ActionResult<ServiceResponse<List<Product>>>> GetProducts()
        {
            var result = await _productService.GetProductsAsync();
            return Ok(result);
        }

        [HttpGet("{productId}")]
        public async Task<ActionResult<ServiceResponse<Product>>> GetProduct(int productId)
        {
            var result = await _productService.GetProductAsync(productId);
            return Ok(result);
        }

        [HttpGet("category/{categoryUrl}")]
        public async Task<ActionResult<ServiceResponse<Product>>> GetProductsByCategory(string categoryUrl)
        {
            var result = await _productService.GetProductsByCategory(categoryUrl);
            return Ok(result);
        }

        [HttpGet("search/{searchtext}/{page}")]
        public async Task<ActionResult<ServiceResponse<ProductSearchResult>>> SearchProducts(string searchtext,int page)
        {
            var result = await _productService.SearchProducts(searchtext, page);
            return Ok(result);
        }

        [HttpGet("searchsuggestion/{searchtext}")]
        public async Task<ActionResult<ServiceResponse<Product>>> GetProductSearchSuggestion(string searchtext)
        {
            var result = await _productService.GetProductSearchSuggestion(searchtext);
            return Ok(result);
        }

        [HttpGet("featured")]
        public async Task<ActionResult<ServiceResponse<Product>>> GetFeaturedProducts()
        {
            var result = await _productService.GetFeaturedProducts();
            return Ok(result);
        }
    }
}
