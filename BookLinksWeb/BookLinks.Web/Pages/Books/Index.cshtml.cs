using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using BookLinks.Repositories.Models;

namespace BookLinks.Web.Pages.Books
{
    public class IndexModel : PageModel
    {
        private readonly BookLinks.Web.Data.BookLinksWebContext _context;

        public IndexModel(BookLinks.Web.Data.BookLinksWebContext context)
        {
            _context = context;
        }

        public IList<Book> Book { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Book != null)
            {
                Book = await _context.Book.ToListAsync();
            }
        }
    }
}
