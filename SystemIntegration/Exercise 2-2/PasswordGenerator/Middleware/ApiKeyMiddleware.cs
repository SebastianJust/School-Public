using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Primitives;

namespace PasswordGenerator.Middleware
{
    internal class ApiKeyMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly string _apiKeyName;
        private readonly string _apiKeyValue;
        public ApiKeyMiddleware(RequestDelegate next, string apiKeyName, string apiKeyValue)
        {
            _next = next;
            _apiKeyName = apiKeyName;
            _apiKeyValue = apiKeyValue;
        }
        public async Task InvokeAsync(HttpContext context)
        {
            if (!context.Request.Headers.TryGetValue(_apiKeyName, out StringValues extractedApiKey))
            {
                context.Response.StatusCode = 401;
                await context.Response.WriteAsync("Api Key was not provided.");
                return;
            }


            if (!_apiKeyValue.Equals(extractedApiKey))
            {
                context.Response.StatusCode = 401;
                await context.Response.WriteAsync("Unauthorized");
                return;
            }

            await _next(context);
        }
    }
}
