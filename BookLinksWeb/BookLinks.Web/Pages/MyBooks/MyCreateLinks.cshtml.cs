using BookLinks.Repositories.Models;
using BookLinks.Repositories.Repositories.Interface;
using BookLinks.Service.Services.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BookLinks.Web.Pages.MyBooks
{
    public class MyCreateLinksModel : PageModel
    {
        private readonly ILinkService _linkService;
        private readonly IBookService _bookService;

        public MyCreateLinksModel(ILinkService linkService, IBookService bookService)
        {
            _linkService = linkService;
            _bookService = bookService;
        }


        [BindProperty]
        public List<Book> AllBooks { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync()
        {
            AllBooks = await _bookService.GetBooksAsync();
            return Page();
        }

        [BindProperty]
        public Link Link { get; set; } = default!;

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid || Link == null)
            {
                return Page();
            }

            await _linkService.AddLinkAsync(Link);
            return RedirectToPage("./My");
        }
    }
}
