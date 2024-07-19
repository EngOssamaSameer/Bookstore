using Microsoft.AspNetCore.Http.HttpResults;
using System.Data;

namespace BookStore.Middleware
{
    public class RateLimitRequest
    {
        private readonly RequestDelegate _next;

        private static int _counter = 0;
        private static DateTime _lastRequest = DateTime.Now;

        public RateLimitRequest(RequestDelegate requestDelegate)
        {
            this._next = requestDelegate;
        }

        public async Task Invoke(HttpContext context)
        {
            _counter++; 
            if(DateTime.Now.Subtract(_lastRequest).Seconds > 10)
            {
                _counter = 1;
                _lastRequest = DateTime.Now;
                await _next(context);
            }
            else
            {
                if(_counter > 4)
                {
                    _lastRequest = DateTime.Now;
                    context.Response.StatusCode = 429;
                    context.Response.ContentType = "text/plain";
                    var userIpAddress = context.Connection.RemoteIpAddress?.ToString();
                    await context.Response.WriteAsync($"{userIpAddress}Rate limit exceeded. Please wait for 10 seconds.");
                }
                else
                {
                    await _next(context);
                    _lastRequest = DateTime.Now;

                }
            }
        }
    }
}
