using Microsoft.AspNetCore.Mvc.Filters;
using System.Diagnostics;

namespace BookStore.Attribute
{
    public class SencitveAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuted(ActionExecutedContext context)
        {
            Debug.WriteLine("✅🤣🤣🤣🤣😭❤️");
        }
    }
}
