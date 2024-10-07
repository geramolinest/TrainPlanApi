using System;
using System.Net;
using TrainPlanApi.Services;

namespace TrainPlanApi.Middlewares;

public class UnauthorizedMiddleware
{
    private readonly RequestDelegate _next;
    public UnauthorizedMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task Invoke(HttpContext context)
    {
        if(context.Response.StatusCode == (int) HttpStatusCode.Unauthorized)
        {
            await context.Response.WriteAsJsonAsync( new ResponseService<object>().UnauthorizedResponse() );
            return;
        }

        await _next(context);
    }
}
