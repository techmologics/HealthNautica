using HealthNautica.Physician.Services;
using Microsoft.AspNetCore.Http;
using Jwt;
using System;
using System.Threading;

namespace HealthNautica.Services
{
    public class JWTTokenGenerator
    {
        private HttpContext _context;

        private string _secret = "HealthNautica";//Need to move this to config
        //private byte[] SecretInByte => Encoding.UTF8.GetBytes(_secret);

        public JWTTokenGenerator(HttpContext context)
        {
            context = _context;
        }

        public string CreateToken(AuthOptions options)
        {
            return JsonWebToken.Encode(options, _secret, JwtHashAlgorithm.HS256);
        }

        public bool IsValidToken(string jwtToken)
        {
            bool isValid = false;
            try
            {
                var payLoad = JsonWebToken.DecodeToObject<AuthOptions>(jwtToken, _secret);
                if (payLoad != null)
                {
                    ThreadLocal<AuthOptions> th = new ThreadLocal<AuthOptions>();
                    th.Value = payLoad;
                    //_context.Items.Add("payload", payLoad);
                    isValid = true;
                }

            }

            //catch (SignatureVerificationException ex)
            //{
            //    //Need to handle this
            //}
            //catch (ArgumentException ex)
            //{
            //    //Need to handle this
            //}
            catch (Exception ex)
            {

            }

            return isValid;



        }


    }
}
