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
    public class AuthOptions       
    {
        public string Name {get; set;} = "test";
    }
}