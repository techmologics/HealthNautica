using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Options;
using System.Security.Claims;
using System.Security.Principal;
using System.Threading.Tasks;

namespace HealthNautica.Physician.Services
{
    /// <summary>
    /// Adds a token generation endpoint to an application pipeline.
    /// </summary>
    public static class AuthExtensions
    {
        /// <summary>
        /// Adds the <see cref="AuthMiddleware"/> middleware to the specified <see cref="IApplicationBuilder"/>, which enables token generation capabilities.
        /// <param name="app">The <see cref="IApplicationBuilder"/> to add the middleware to.</param>
        /// <param name="options">A  <see cref="AuthOptions"/> that specifies options for the middleware.</param>
        /// <returns>A reference to this instance after the operation has completed.</returns>
        public static IApplicationBuilder UseTokenAuthentication(this IApplicationBuilder app, AuthOptions options)
        {
            if (app == null)
            {
                throw new ArgumentNullException(nameof(app));
            }

            if (options == null)
            {
                throw new ArgumentNullException(nameof(options));
            }

            return app.UseMiddleware<AuthMiddleware>(Options.Create(options));
        }
    }
}