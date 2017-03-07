using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Options;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace HealthNautica.Physician.Services
{
    /// <summary>
    /// Adds a token generation endpoint to an application pipeline.
    /// </summary>
    public class AuthMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly AuthOptions _options;
        private readonly ILogger _logger;

        public AuthMiddleware(
            RequestDelegate next,
            IOptions<AuthOptions> options,
            ILoggerFactory loggerFactory)
        {
            _next = next;
            _logger = loggerFactory.CreateLogger<AuthMiddleware>();
            _options = options.Value;
        }

        public Task Invoke(HttpContext context)
        {
            _logger.LogInformation("Pre Handling request: " + context.Request.Path);
            // If the request path doesn't match, skip
            if (!context.Request.Path.Equals("/api/login", StringComparison.Ordinal))
            {
                return _next(context);
            }
            _logger.LogInformation("Post Handling request: " + context.Request.Path);
            // Serialize and return the response
            var response = new
            {
                access_token = "test token"
            };
            context.Response.ContentType = "application/json";
            return context.Response.WriteAsync(JsonConvert.SerializeObject(response, new JsonSerializerSettings
            {
                Formatting = Formatting.Indented
            }));
        }

    }
}