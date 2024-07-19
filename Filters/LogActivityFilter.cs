using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc.Filters;

namespace BookStore.Filters
{
    public class LogActivityFilter : IActionFilter
    {
        private readonly ILogger<LogActivityFilter> logger;

        public LogActivityFilter(ILogger<LogActivityFilter> logger)
        {
            this.logger = logger;
        }
        public void OnActionExecuted(ActionExecutedContext context)
        {
            logger.LogInformation("✅✅✅✅✅✅✅ after executing");
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            logger.LogInformation("🥳🥳🥳🥳🥳🥳🥳 befor executing");
        }
    }
}









