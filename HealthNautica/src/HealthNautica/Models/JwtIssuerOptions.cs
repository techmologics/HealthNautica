using System;
using System.Threading.Tasks;
using Microsoft.IdentityModel.Tokens;
namespace HealthNautica.Models
{
    public class JwtIssuerOptions
    {
        public string Issuer { get; set; }

        public string Subject { get; set; }

        public string Audience { get; set; }

        public DateTime IssuedAt { get; set; } = DateTime.UtcNow;

        public TimeSpan ValidFor { get; set; } = TimeSpan.FromMinutes(5);

        public DateTime Expiration => IssuedAt.Add(ValidFor);

        public string JtiGenerator => Guid.NewGuid().ToString();

        public SigningCredentials SigningCredentials { get; set; }
    }
}
