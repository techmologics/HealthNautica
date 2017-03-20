using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Internal;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthNautica.Extensions
{
    public static class HttpContextExtensions
    {
        public async static Task<string> ReadAsString(this HttpRequest request)
        {
            var initialBody = request.Body; // Workaround

            request.EnableRewind();
            var buffer = new byte[Convert.ToInt32(request.ContentLength)];
            await request.Body.ReadAsync(buffer, 0, buffer.Length);
            var body = Encoding.UTF8.GetString(buffer);
            request.Body = initialBody; // Workaround
            return body;
        }

        public async static Task<T> ReadAsAsync<T>(this HttpRequest request)
        {
            var json = await request.ReadAsString();
            T retValue = JsonConvert.DeserializeObject<T>(json);
            return retValue;
        }
    }
}
