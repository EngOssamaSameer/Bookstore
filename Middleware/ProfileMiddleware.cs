using System.Diagnostics;

namespace BookStore.Middleware
{
    public class ProfileMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ProfileMiddleware> _logger;

        public ProfileMiddleware(RequestDelegate next,ILogger<ProfileMiddleware> logger)
        {
            this._next = next;
            this._logger = logger;
        }

        public async Task Invoke(HttpContext context)
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            await _next(context);
            stopwatch.Stop();

            _logger.LogInformation($"✅✅ reqoust on {context.Request.Path} take : {stopwatch.ElapsedMilliseconds} ms ");

        }
    }
}
