using System;
using Microsoft.Extensions.Options;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using HealthNautica.Services;
using System.Security.Cryptography;

namespace HealthNautica.Physician.Services
{
    /// <summary>
    /// Adds a token generation endpoint to an application pipeline.
    /// </summary>
    public class JwtAuthMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly AuthOptions _options;
        private readonly ILogger _logger;

        public JwtAuthMiddleware(
            RequestDelegate next,
            IOptions<AuthOptions> options,
            ILoggerFactory loggerFactory)
        {
            _next = next;
            _logger = loggerFactory.CreateLogger<JwtAuthMiddleware>();
            _options = options.Value;
        }

        public Task Invoke(HttpContext context)
        {
            _logger.LogInformation("Pre Handling request: " + context.Request.Path);
            if (!context.Request.Path.Equals("/api/login", StringComparison.Ordinal))
            {
                if (IsValidToken(context))
                    return _next(context);
                else
                {
                    context.Response.StatusCode = 401; //UnAuthorized
                    return context.Response.WriteAsync("UnAuthorized");
                }
            }
            else
            {
                var token = CreateToken(context);
                if (token != null)
                {
                    var response = new
                    {
                        access_token = token
                    };
                    context.Response.ContentType = "application/json";
                    return context.Response.WriteAsync(JsonConvert.SerializeObject(response, new JsonSerializerSettings
                    {
                        Formatting = Formatting.Indented
                    }));
                }
                context.Response.StatusCode = 401; //UnAuthorized
                return context.Response.WriteAsync("UnAuthorized");

            }
            // _logger.LogInformation("Post Handling request: " + context.Request.Path);
            // Serialize and return the response
            //var response = new
            //{
            //    access_token = "test token"
            //};
            //context.Response.ContentType = "application/json";
            //return context.Response.WriteAsync(JsonConvert.SerializeObject(response, new JsonSerializerSettings
            //{
            //    Formatting = Formatting.Indented
            //}));
        }

        private string CreateToken(HttpContext context)
        {
            string userName = context.Request.Form["username"];
            string password = context.Request.Form["password"];
            var isValid = new SignInManager(userName, password).ValidateUser();
            string token = null;
            if (isValid)
            {
                token = new JWTTokenGenerator(context).CreateToken(new AuthOptions
                {
                    Name = "Abc",
                    UserName = userName,
                    Role = "Admin"
                });
            }

            return token;
        }

        private bool IsValidToken(HttpContext context)
        {
            string authHeader = context.Request.Headers["Authorization"];
            var token = authHeader.Substring(authHeader.IndexOf(' ') + 1);
            return new JWTTokenGenerator(context).IsValidToken(token);
        }
    }
}