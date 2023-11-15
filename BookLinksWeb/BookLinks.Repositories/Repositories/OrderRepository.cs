using BookLinks.Repositories.Models;
using BookLinks.Repositories.Repositories.Interface;
using Microsoft.EntityFrameworkCore;

namespace BookLinks.Repositories.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private readonly DataContext _dataContext;

        public OrderRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task CreateNewOrderAsync(Order order)
        {
            _dataContext.Orders.Add(order);
            await _dataContext.SaveChangesAsync();
        }

        public async Task<Order> GetOrderByIdAsync(int id)
        {
            var order = await _dataContext.Orders
                .Include(b => b.BookOrders)
                .ThenInclude(b => b.Book)
                .Include(u => u.User)
                .FirstOrDefaultAsync(o => o.UserId == id && o.IsActive == true);
            return order;
        }

        public async Task UpdateOrderAsync(int userId, int bookId)
        {
            var user = await _dataContext.Users.Include(o => o.Orders).FirstOrDefaultAsync(u => u.Id == userId);
            if (user != null)
            {
                var bookOrder = new BookOrder()
                {
                    OrderId = user.Orders.First(o => o.IsActive == true).Id,
                    BookId = bookId
                };
                await _dataContext.BookOrders.AddAsync(bookOrder);
            }
            await _dataContext.SaveChangesAsync();
        }

        public async Task UpdateOrderByBookIdAsync(Order order)
        {
            _dataContext.Orders.Update(order);
            await _dataContext.SaveChangesAsync();
        }
    }
}
