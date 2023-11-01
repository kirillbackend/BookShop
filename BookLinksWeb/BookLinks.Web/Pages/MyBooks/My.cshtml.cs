using BookLinks.Repositories.Models;
using BookLinks.Service.Services.Interface;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BookLinks.Web.Pages.MyBooks
{
    public class MyModel : PageModel
    {
        private readonly IBookService _bookService;

        public MyModel(IBookService bookService)
        {
            _bookService = bookService;
        }

        public IList<Book> Book { get; set; } = default!;

        public async Task OnGet()
        {
            Book = await _bookService.GetBooksAsync();
        } 
    }
}
