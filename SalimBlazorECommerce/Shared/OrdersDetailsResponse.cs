using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalimBlazorECommerce.Shared
{
    public class OrdersDetailsResponse
    {
        public DateTime OrderDate { get; set; }
        public Decimal TotalPrice { get; set; }
        public List<OrderDetailsProductsResponse> Products { get; set; }
    }
}
