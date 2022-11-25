namespace SalimBlazorECommerce.Server.Services.ProductService
{
    public class ProductService : IProductService
    {
        private readonly DataContext _context;

        public ProductService(DataContext context)
        {
            _context = context;
        }

        public async Task<ServiceResponse<List<Product>>> GetFeaturedProducts()
        {
            var response = new ServiceResponse<List<Product>>
            {
                Data = await _context.Products.Where(p => p.Featured).Include(p => p.Variants).ToListAsync()
            };
            return response;
        }

        public async Task<ServiceResponse<Product>> GetProductAsync(int productId)
        {
            var response = new ServiceResponse<Product>();
            var product = await _context.Products.Include(p => p.Variants).ThenInclude(v => v.ProductType).FirstOrDefaultAsync(p => p.Id == productId);
            if (product == null)
            {
                response.Success = false;
                response.Message = "Sorry but this product does not exist.";
            }
            else
            {
                response.Data = product;
            }
            return response;
        }

        public async Task<ServiceResponse<List<Product>>> GetProductsAsync()
        {
            var response = new ServiceResponse<List<Product>>()
            {
                Data = await _context.Products.Include(p => p.Variants).ToListAsync()
            };

            return response;
        }

        public async Task<ServiceResponse<List<Product>>> GetProductsByCategory(string categoryUrl)
        {
            var response = new ServiceResponse<List<Product>>
            {
                Data = await _context.Products.Where(p => p.Category.Url.ToLower().Equals(categoryUrl)).Include(p => p.Variants).ToListAsync()
            };

            return response;

        }

        public async Task<ServiceResponse<List<string>>> GetProductSearchSuggestion(string searchtext)
        {
            var products = await FindProductBySearchText(searchtext);

            List<string> result = new List<string>();

            foreach (var product in products)
            {
                if (product.Title.Contains(searchtext, StringComparison.OrdinalIgnoreCase))
                {
                    result.Add(product.Title);
                }

                if(product.Description != null)
                {
                    var punctuation = product.Description.Where(char.IsPunctuation).Distinct().ToArray();
                    var words = product.Description.Split().Select(s => s.Trim(punctuation));

                    foreach(var word in words)
                    {
                        if(word.Contains(searchtext, StringComparison.OrdinalIgnoreCase)
                            && !result.Contains(word))
                        {

                            result.Add(word);
                        }
                    }
                }
            }

            return new ServiceResponse<List<string>> { Data = result };
        }

        public async Task<ServiceResponse<ProductSearchResult>> SearchProducts(string searchtext, int page)
        {
            var pageResult = 2f;
            var pageCount = Math.Ceiling((await FindProductBySearchText(searchtext)).Count / pageResult);
            var products = await _context.Products
                            .Where(p => p.Title.ToLower().Contains(searchtext.ToLower())
                            ||
                            p.Description.ToLower().Contains(searchtext.ToLower()))
                            .Include(p => p.Variants)
                            .Skip((page - 1) * (int)pageResult)
                            .Take((int)pageResult)
                            .ToListAsync();

            var response = new ServiceResponse<ProductSearchResult>
            {
                Data = new ProductSearchResult
                {
                    Products = products,
                    CurrentPage = page,
                    Pages = (int)pageCount
                }
            };
            return response;
        }

        private async Task<List<Product>> FindProductBySearchText(string searchtext)
        {
            return await _context.Products
                            .Where(p => p.Title.ToLower().Contains(searchtext.ToLower())
                            ||
                            p.Description.ToLower().Contains(searchtext.ToLower()))
                            .Include(p => p.Variants).ToListAsync();
        }
    }
}
