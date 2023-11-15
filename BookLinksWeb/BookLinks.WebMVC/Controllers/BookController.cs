using AutoMapper;
using BookLinks.Common.Enums;
using BookLinks.Service.Models;
using BookLinks.Service.Services.Interface;
using BookLinks.WebMVC.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BookLinks.WebMVC.Controllers
{
    [Authorize]
    public class BookController : Controller
    {
        private readonly ILogger<BookController> _logger;
        private readonly IBookService _bookService;
        private readonly IMapper _mapper;

        public BookController(ILogger<BookController> logger, IBookService bookService, IMapper mapper)
        {
            _logger = logger;
            _bookService = bookService;
            _mapper = mapper;
        }
        
        public async Task<IActionResult> Index(string? searchString, BookOptiosEnum option)
        {
            var allBooksDto = await _bookService.GetBooksAsync();
            if (!string.IsNullOrEmpty(searchString))
            {
                var result = await _bookService.GetFilterBook(searchString, allBooksDto, option);
                var filterBooks = _mapper.Map<List<BookModel>>(result);
                return View(filterBooks);
            }
            else
            {
                var allBooks = _mapper.Map<List<BookModel>>(allBooksDto);
                return View(allBooks);
            }
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var bookDto = await _bookService.GetBookByIdAsync(id);
            if (bookDto == null)
            {
                return NotFound();
            }
            var book = _mapper.Map<BookModel>(bookDto);
            return View(book);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(BookModel book)
        {
            if (book == null)
            {
                throw new ArgumentNullException(nameof(book));
            }
            else
            {
                var bookDto = _mapper.Map<BookDto>(book);
                await _bookService.UpdateBookAsync(bookDto);
                return RedirectToAction(nameof(Index));
            }
        }

        [AllowAnonymous]
        [HttpGet]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                throw new ArgumentNullException(nameof(id));
            }
            else
            {
                var bookDto = await _bookService.GetBookByIdAsync(id);
                var book = _mapper.Map<BookModel>(bookDto);
                return View(book);
            }
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var bookDto = await _bookService.GetBookByIdAsync(id);
            var book = _mapper.Map<BookModel>(bookDto);
            return View(book);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                throw new ArgumentNullException(nameof(id));
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
        public async Task<IActionResult> Create(BookModel book)
        {
            if (book == null)
            {
                throw new ArgumentNullException(nameof(book));
            }
            else
            {
                var bookDto = _mapper.Map<BookDto>(book);
                await _bookService.AddBookAsync(bookDto);
                return RedirectToAction(nameof(Index));
            }
        }
    }
}
