using BookLinks.Repositories.Models;
using BookLinks.Service.Services.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BookLinks.Web.Pages.MyBooks
{
    public class MyDetailsModel : PageModel
    {
        private readonly IBookService _bookService;

        public MyDetailsModel(IBookService bookService)
        {
            _bookService = bookService;
        }

        [BindProperty]
        public Book Book { get; set; } = default!;

        public async Task OnGetAsync(int? id)
        {
            if (id != null)
            {
                Book = await _bookService.GetBookByIdAsync(id);
            }
        }
    }
}
