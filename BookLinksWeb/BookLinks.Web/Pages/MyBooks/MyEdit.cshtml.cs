using BookLinks.Repositories.Models;
using BookLinks.Service.Services.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BookLinks.Web.Pages.MyBooks
{
    public class MyEditModel : PageModel
    {
        private readonly IBookService _bookService;

        public MyEditModel(IBookService bookService)
        {
            _bookService = bookService;
        }

        [BindProperty] 
        public Book Book { get; set; } = default!;


        public async Task<IActionResult> OnGetAsync(int? id)
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
            Book = book;
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            else
            {
                await _bookService.UpdateBookAsync(Book);
               return RedirectToPage("./My");
            }
        }
    }
}
