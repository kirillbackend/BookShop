using AutoMapper;
using BookLinks.Repositories.Models;
using BookLinks.Repositories.Repositories.Interface;
using BookLinks.Service.Models;
using BookLinks.Service.Services.Interface;

namespace BookLinks.Service.Services
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IMapper _mapper;

        public OrderService(IOrderRepository orderRepository, IMapper mapper)
        {
            _orderRepository = orderRepository;
            _mapper = mapper;
        }

        public async Task<OrderDto> GetOrderByUserIdAsync(int id)
        {
            var order = await _orderRepository.GetOrderByIdAsync(id);
            var orderDto = _mapper.Map<Order,OrderDto>(order);
            return orderDto;
        }

        public async Task CreateNewOrderAsync(int userId)
        {
            OrderDto orderDto = new OrderDto();
            orderDto.UserId = userId;
            orderDto.Created = DateTime.UtcNow;
            orderDto.Update = DateTime.UtcNow;
            orderDto.IsActive = true;
            var order = _mapper.Map<Order>(orderDto);
            await _orderRepository.CreateNewOrderAsync(order);
        }

        public async Task UpdateOrderAsync(int userId, int bookId)
        {
            await _orderRepository.UpdateOrderAsync(userId, bookId);
        }

        public async Task UpdateOrderByBookIdAsync(OrderDto orderDto)
        {
            var order = _mapper.Map<Order>(orderDto);
            await _orderRepository.UpdateOrderByBookIdAsync(order);
        }
    }
}
