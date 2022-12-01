namespace SalimBlazorECommerce.Client.Services.OrderService
{
    public interface IOrderService
    {
        Task<string> PlaceOrder();
        Task<List<OrderOverviewResponse>> GetOrders();
        Task<OrdersDetailsResponse> GetOrderDetails(int orderId);
    }
}
