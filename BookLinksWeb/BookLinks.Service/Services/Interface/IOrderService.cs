using BookLinks.Service.Models;

namespace BookLinks.Service.Services.Interface
{
    public interface IOrderService
    {
        Task<OrderDto> GetOrderByUserIdAsync(int id);
        Task UpdateOrderAsync(int userId, int bookId);
        Task CreateNewOrderAsync(int userId);
        Task UpdateOrderByBookIdAsync(OrderDto orderDto);
    }
}