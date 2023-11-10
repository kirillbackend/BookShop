using BookLinks.Common.Enums;
using BookLinks.Repositories.Models;
using BookLinks.Repositories.Repositories.Interface;
using BookLinks.Service.Services.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BookLinks.WebMVC.Controllers
{
    [Authorize]
    public class LinkController : Controller
    {
        private readonly ILinkService _linkService;
        private readonly IBookService _bookService;

        public LinkController(ILinkService linkService, IBookService bookService)
        {
            _linkService = linkService;
            _bookService = bookService;
        }

        [HttpGet]
        public async Task<IActionResult>Index(string? searchString, LinkOptiosEnum option)
        {
            var allLinks = await _linkService.GetLinksAsync();
            if (!string.IsNullOrEmpty(searchString))
            {
                var result = await _linkService.GetFilterLink(searchString, allLinks, option);
                return View(result);
            }
            return View(allLinks);
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            ViewBag.Books = await _bookService.GetBooksAsync();
            return View();  
        }

        [HttpPost]
        public async Task<IActionResult> Create(Link link)
        {
            await _linkService.AddLinkAsync(link);
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var link = await _linkService.GetLinkByIdAsync(id);
            return View(link);
        }

        [HttpPost]
        public async Task<IActionResult> Create(Book book)
        {
            await _bookService.AddBookAsync(book);
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var link = await _linkService.GetLinkByIdAsync(id);
            if (link == null)
            {
                return NotFound();
            }
            ViewBag.Books = await _bookService.GetBooksAsync();
            return View(link);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Link link)
        {
            await _linkService.UpdateLinkAsync(link);   
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            else
            {
                var link = await _linkService.GetLinkByIdAsync(id);
                return View(link);
            }
        }
    }
}
