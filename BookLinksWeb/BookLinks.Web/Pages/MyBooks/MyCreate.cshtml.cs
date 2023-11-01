using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using BookLinks.Repositories.Models;
using BookLinks.Service.Services.Interface;

namespace BookLinks.Web.Pages.MyBooks
{
    public class MyCreateModel : PageModel
    {
        private readonly IBookService _bookService;

        public MyCreateModel(IBookService bookService)
        {
            _bookService = bookService;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Book Book { get; set; } = default!;


        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid || Book == null)
            {
                return Page();
            }

            await _bookService.AddBookAsync(Book);
            return RedirectToPage("./My");
        }
    }
}
