using BookLinks.Repositories.Models;
using BookLinks.Repositories.Repositories.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BookLinks.Web.Pages.MyBooks
{
    public class MyEditLinksModel : PageModel
    {
        private readonly ILinkService _linkService;

        public MyEditLinksModel(ILinkService linkService)
        {
            _linkService = linkService;
        }

        [BindProperty]
        public List<Link> Links { get; set; } = default!;

        [BindProperty]
        public Link Link { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync()
        {
            Links = await _linkService.GetLinksAsync();
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
                await _linkService.UpdateLinkAsync(Link);
                return RedirectToPage("./My");
            }
        }
    }
}
