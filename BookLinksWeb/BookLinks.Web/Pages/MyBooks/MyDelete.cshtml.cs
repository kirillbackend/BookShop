using BookLinks.Repositories.Models;
using BookLinks.Repositories.Repositories.Interface;
using BookLinks.Service.Services.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BookLinks.Web.Pages.MyBooks
{
    public class MyDeleteModel : PageModel
    {
        private readonly IBookService _bookService;

        public MyDeleteModel(IBookService bookService)
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
            else
            {
                Book = await _bookService.GetBookByIdAsync(id);
                return Page();
            }
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            else
            {
                await _bookService.DeleteBookAsync(id);
                return RedirectToPage("./My");
            } 
        }
    }
}
