using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace BookLinks.Rest.Api.Controllers
{
    public class AbstractController : ControllerBase
    {
        public ILogger Logger { get; set; }

        public AbstractController(ILogger logger)
        {
           Logger = logger;
        }

        protected BadRequestObjectResult BadRequest(ValidationException exception)
        {
            return new BadRequestObjectResult(ModelState)
            {
                Value = new
                {
                    message = exception.Message,

                    // создать свой ValidationException по примеру.
                    //uiMessage = exception.UIMessage,
                    //source = exception.ValidationSource
                }
            };
        }
    }
}
