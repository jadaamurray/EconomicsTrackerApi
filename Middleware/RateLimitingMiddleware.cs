using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Concurrent;
using System.Threading.Tasks;

public class RateLimitingMiddleware
{
    private static readonly ConcurrentDictionary<string, RequestCounter> _requestCounters = new();
    private readonly RequestDelegate _next;
    private readonly int _limit;
    private readonly TimeSpan _timeWindow;

    public RateLimitingMiddleware(RequestDelegate next, int limit, TimeSpan timeWindow)
    {
        _next = next;
        _limit = limit;
        _timeWindow = timeWindow;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        var clientIp = context.Connection.RemoteIpAddress.ToString();
        var currentTime = DateTime.UtcNow;

        var requestCounter = _requestCounters.GetOrAdd(clientIp, new RequestCounter { LastRequestTime = currentTime, RequestCount = 0 });

        if (currentTime - requestCounter.LastRequestTime > _timeWindow)
        {
            requestCounter.RequestCount = 0;
            requestCounter.LastRequestTime = currentTime;
        }

        if (requestCounter.RequestCount >= _limit)
        {
            context.Response.StatusCode = StatusCodes.Status429TooManyRequests;
            await context.Response.WriteAsync("Too many requests. Please try again later.");
            return;
        }

        requestCounter.RequestCount++;
        await _next(context);
    }
}

public class RequestCounter
{
    public int RequestCount { get; set; }
    public DateTime LastRequestTime { get; set; }
}
