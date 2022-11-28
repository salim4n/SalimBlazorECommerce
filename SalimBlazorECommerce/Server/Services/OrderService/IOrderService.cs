﻿namespace SalimBlazorECommerce.Server.Services.OrderService
{
    public interface IOrderService
    {
        Task<ServiceResponse<bool>> PlaceOrder();
        Task<ServiceResponse<List<OrderOverviewResponse>>> GetOrders();
        Task<ServiceResponse<OrdersDetailsResponse>> GetOrdersDetails(int orderId);
        

        
    }
}
