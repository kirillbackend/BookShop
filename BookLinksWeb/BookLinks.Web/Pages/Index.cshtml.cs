using BookLinks.Common.Enums;
using BookLinks.Repositories.Models;
using BookLinks.Service.Services.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BookLinks.Web.Pages
{
    public class IndexModel : PageModel
    {
        private readonly IBookService _bookService;
        public IndexModel(IBookService bookService)
        {
            _bookService = bookService;
        }

        public IList<Book> Book { get; set; } = default!;
        [BindProperty(SupportsGet = true)]
        public string? SearchString { get; set; }

        [BindProperty(SupportsGet = true)]
        public BookOptiosEnum Option { get; set; }

        public async Task OnGetAsync()
        {
            var allBook = await _bookService.GetBooksAsync();

            if (!string.IsNullOrEmpty(SearchString))
            {
                Book = await _bookService.GetFilterBook(SearchString, allBook, Option);
            }
            else
            {
                Book = allBook;
            }
        }
    }
}
