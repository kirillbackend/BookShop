using BookLinks.Common.Enums;
using BookLinks.Repositories.Models;
using BookLinks.Service.Services.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BookLinks.WebMVC.Controllers
{
    [Authorize]
    public class BookController : Controller
    {
        private readonly ILogger<BookController> _logger;
        private readonly IBookService _bookService;

        public BookController(ILogger<BookController> logger, IBookService bookService)
        {
            _logger = logger;
            _bookService = bookService;
        }

        
        public async Task<IActionResult> Index(string? searchString, BookOptiosEnum option)
        {
            var allBook = await _bookService.GetBooksAsync();
            if (!string.IsNullOrEmpty(searchString))
            {
                var result = await _bookService.GetFilterBook(searchString, allBook, option);
                return View(result);
            }
            else
                return View(allBook);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var book = await _bookService.GetBookByIdAsync(id);
            if (book == null)
            {
                return NotFound();
            }
            return View(book);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Book book)
        {
            await _bookService.UpdateBookAsync(book);
            return  RedirectToAction(nameof(Index));
        }

        [AllowAnonymous]
        [HttpGet]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            else
            {
                var book = await _bookService.GetBookByIdAsync(id);
                return View(book);
            }
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var book = await _bookService.GetBookByIdAsync(id);
            return View(book);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            else
            {
                await _bookService.DeleteBookAsync(id);
                return RedirectToAction(nameof(Index));
            }
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Book book)
        {
            await _bookService.AddBookAsync(book);
            return RedirectToAction(nameof(Index));
        }
    }
}
