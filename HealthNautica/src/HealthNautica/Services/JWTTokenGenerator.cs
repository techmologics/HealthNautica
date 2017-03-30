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
            if (!string.IsNullOrEmpty(jwtToken))
                return false;
            bool isValid = false;
            try
            {
                var payLoad = JsonWebToken.DecodeToObject<AuthOptions>(jwtToken, _secret);
                if (payLoad != null)
                {
                    AddToThread(payLoad);
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
                //Ignored
            }

            return isValid;



        }

        private void AddToThread(AuthOptions payLoad)
        {

            int threadId = Thread.CurrentThread.ManagedThreadId;
            // Thread.SetData(Thread.GetNamedDataSlot(threadId.ToString()), payLoad);

        }
    }
}
