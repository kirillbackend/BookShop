using AutoMapper;
using BookLinks.Service.Services.Interface;
using BookLinks.WebMVC.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BookLinks.WebMVC.Controllers
{
    [AllowAnonymous]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IBookService _bookService;
        private readonly IMapper _mapper;
        private readonly IOrderService _orderService;
        private readonly IUserService _userService;

        public HomeController(ILogger<HomeController> logger, IBookService bookService, IMapper mapper, IOrderService orderService, IUserService userService)
        {
            _logger = logger;
            _bookService = bookService;
            _mapper = mapper;
            _orderService = orderService;
            _userService = userService; 
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var allBooksDto = await _bookService.GetBooksAsync();
            var allBook = _mapper.Map<List<BookModel>>(allBooksDto);
            var user = HttpContext.User.Claims.Where(i => i.Type == "id").FirstOrDefault();

            if (user != null)
            {
                var userId = Convert.ToInt32(user.Value);
                var userDto = await _userService.GetUserByIdAsync(userId);

                if (userDto.Orders.Where(o => o.IsActive == true).Count() == 0)
                {
                    await _orderService.CreateNewOrderAsync(userId);
                }

                var orderDto = await _orderService.GetOrderByUserIdAsync(userId);
                var orderModel = _mapper.Map<OrderModel>(orderDto);
                ViewBag.Order = orderModel.BookOrdersModel.Select(b => b.Book).Select(b => b.Id).ToList();
            }

            return View(allBook);
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> Index(int bookId)
        {
            var userId = Convert.ToInt32(HttpContext.User.Claims.Where(i => i.Type == "id").First().Value);
            await _orderService.UpdateOrderAsync(userId, bookId);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Privacy()
        {
            return View();
        }
    }
}