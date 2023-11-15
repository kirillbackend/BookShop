using AutoMapper;
using BookLinks.Service.Services.Interface;
using BookLinks.WebMVC.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BookLinks.WebMVC.Controllers
{
    public class BasketController : Controller
    {
        private readonly IOrderService _orderService;
        private readonly IMapper _mapper;

        public BasketController(IOrderService orderService, IMapper mapper)
        {
            _orderService = orderService;
            _mapper = mapper;
        }

        [Authorize]
        public async Task<IActionResult> Index()
        {
            var userId = Convert.ToInt32(HttpContext.User.Claims.Where(i => i.Type == "id").First().Value);
            var orderDto = await _orderService.GetOrderByUserIdAsync(userId);
            var order = _mapper.Map<OrderModel>(orderDto);
            return View(order);
        }
    }
}
