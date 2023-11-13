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

        public HomeController(ILogger<HomeController> logger, IBookService bookService, IMapper mapper)
        {
            _logger = logger;
            _bookService = bookService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var allBooksDto = await _bookService.GetBooksAsync();
            var allBook = _mapper.Map<List<BookModel>>(allBooksDto);
            return View(allBook);
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> Index(int id)
        {
            var userName = HttpContext.User.Claims.Where(i => i.Type == "id").First().Value;
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Privacy()
        {
            return View();
        }
    }
}