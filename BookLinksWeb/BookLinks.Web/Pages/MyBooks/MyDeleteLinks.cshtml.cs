using BookLinks.Repositories.Models;
using BookLinks.Repositories.Repositories.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BookLinks.Web.Pages.MyBooks
{
    public class MyDeleteLinksModel : PageModel
    {
        private readonly ILinkService _linkService;

        public MyDeleteLinksModel(ILinkService linkService)
        {
            _linkService = linkService;
        }

        [BindProperty]
        public List<Link> Links { get; set; } = default!;

        [BindProperty]
        public int Id { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync()
        {
            Links = await _linkService.GetLinksAsync();
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (Id == null)
            {
                return NotFound();
            }
            else
            {
                await _linkService.DeleteLinkAsync(Id);
                return RedirectToPage("./My");
            }
        }
    }
}
