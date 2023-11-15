using AutoMapper;
using BookLinks.Common.Enums;
using BookLinks.Service.Models;
using BookLinks.Service.Services;
using BookLinks.Service.Services.Interface;
using BookLinks.WebMVC.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BookLinks.WebMVC.Controllers
{
    [Authorize]
    public class LinkController : Controller
    {
        private readonly ILinkService _linkService;
        private readonly IBookService _bookService;
        private readonly IMapper _mapper;

        public LinkController(ILinkService linkService, IBookService bookService, IMapper mapper)
        {
            _linkService = linkService;
            _bookService = bookService;
            _mapper = mapper;
        }

        public async Task<IActionResult>Index(string? searchString, LinkOptionsEnum option)
        {
            var allLinksDto = await _linkService.GetLinksAsync();
            if (!string.IsNullOrEmpty(searchString))
            {
                var result = await _linkService.GetFilterLink(searchString, allLinksDto, option);
                var filterLinks = _mapper.Map<List<LinkModel>>(result);
                return View(filterLinks);
            }
            else
            {
                var allLinks = _mapper.Map<List<LinkModel>>(allLinksDto);
                return View(allLinks);
            }
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            var booksDto = await _bookService.GetBooksAsync();
            ViewBag.Books = _mapper.Map<List<BookModel>>(booksDto);
            return View();  
        }

        [HttpPost]
        public async Task<IActionResult> Create(LinkModel link)
        {
            if (link == null)
            {
                throw new ArgumentNullException(nameof(link));
            }
            else
            {
                var linkDto = _mapper.Map<LinkDto>(link);
                await _linkService.AddLinkAsync(linkDto);
                return RedirectToAction(nameof(Index));
            }
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var linkDto = await _linkService.GetLinkByIdAsync(id);
            var link = _mapper.Map<LinkModel>(linkDto);
            return View(link);
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
                await _linkService.DeleteLinkAsync(id);
                return RedirectToAction(nameof(Index));
            }
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var linkDto = await _linkService.GetLinkByIdAsync(id);
            if (linkDto == null)
            {
                return NotFound();
            }
            var link = _mapper.Map<LinkModel>(linkDto);
            var allBooksDto = await _bookService.GetBooksAsync();
            ViewBag.Books = _mapper.Map<List<BookModel>>(allBooksDto);
            return View(link);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(LinkModel link)
        {
            if (link == null)
            {
                throw new ArgumentNullException(nameof(link));
            }
            else
            {
                var linkDto = _mapper.Map<LinkDto>(link);
                await _linkService.UpdateLinkAsync(linkDto);
                return RedirectToAction(nameof(Index));
            }
        }

        [HttpGet]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                throw new ArgumentNullException(nameof(id));
            }
            else
            {
                var linkDto = await _linkService.GetLinkByIdAsync(id);
                var link = _mapper.Map<LinkModel>(linkDto);
                return View(link);
            }
        }
    }
}
