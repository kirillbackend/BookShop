using BookLinks.Repositories.Models;

namespace BookLinks.Repositories.Repositories.Interface
{
    public interface IOrderRepository
    {
        Task<Order> GetOrderByIdAsync(int id);
        Task CreateNewOrderAsync(Order order);
        Task UpdateOrderAsync(int userId, int bookId);
        Task UpdateOrderByBookIdAsync(Order order);
    }
}