using Microsoft.AspNetCore.Mvc;

namespace BookLinks.WebMVC.Controllers
{
    public class BasketController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
