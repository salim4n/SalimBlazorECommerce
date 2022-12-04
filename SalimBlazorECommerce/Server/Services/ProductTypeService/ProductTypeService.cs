using SalimBlazorECommerce.Server.Controllers;

namespace SalimBlazorECommerce.Server.Services.ProductTypeService
{
    public class ProductTypeService : IProductTypeService
    {
        private readonly DataContext _context;

        public ProductTypeService(DataContext context)
        {
            _context = context;
        }

        public async Task<ServiceResponse<List<ProductType>>> AddProductType(ProductType productType)
        {
            productType.Editing = productType.IsNew = false;
            _context.ProductTypes.Add(productType);
            await _context.SaveChangesAsync();

            return await GetProductType();
        }

        public async Task<ServiceResponse<List<ProductType>>> GetProductType()
        {
            var productTypes = await _context.ProductTypes.ToListAsync();
            return new ServiceResponse<List<ProductType>> { Data = productTypes };
        }

        public async Task<ServiceResponse<List<ProductType>>> UpdateProductType(ProductType productType)
        {
            var dbProduct = await _context.ProductTypes.FindAsync(productType.Id);
            if(dbProduct == null)
            {
                return new ServiceResponse<List<ProductType>>
                {
                    Success = false,
                    Message = "Product Type not found"
                };
            }

            dbProduct.Name = productType.Name;
            await _context.SaveChangesAsync();

            return await GetProductType();
        }
    }
}
