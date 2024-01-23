using Microsoft.AspNetCore.Mvc.Filters;

namespace BookLinks.WebMVC.ActionFilters
{
    public class LogActionFilter : Attribute, IResourceFilter
    {
        public void OnResourceExecuting(ResourceExecutingContext context)
        {
            Console.WriteLine("ActionResourceFilter.OnResourceExecuting");
        }

        public void OnResourceExecuted(ResourceExecutedContext context)
        {
            Console.WriteLine("ActionResourceFilter.OnResourceExecuted");
        }
    }
}
