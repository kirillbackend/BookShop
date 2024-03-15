using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BookLinks.Rest.Api.Controllers
{
    [Route("book")]
    [ApiController]
    [Authorize]
    public class BookController : AbstractController
    {
        public BookController(ILogger<BookController> logger) : base(logger)
        {
        }


    }
}
