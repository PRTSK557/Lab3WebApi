using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System;
using System.Net;
using System.Threading.Tasks;

namespace ProksRent_WebAPI.Middleware
{
    public class GlobalExceptionHandlingMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<GlobalExceptionHandlingMiddleware> _logger;

        public GlobalExceptionHandlingMiddleware(RequestDelegate next, ILogger<GlobalExceptionHandlingMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext httpContext)
        {
            try
            {
                // Continue with the request pipeline
                await _next(httpContext);
            }
            catch (Exception ex)
            {
                // Log the error
                _logger.LogError($"Something went wrong: {ex}");

                // Set response status code and write the error response
                httpContext.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                httpContext.Response.ContentType = "application/json";

                // You can return a more specific error message if needed
                await httpContext.Response.WriteAsync(new
                {
                    message = "An unexpected error occurred. Please try again later."
                }.ToString());
            }
        }
    }
}
