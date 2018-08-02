using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace ApiTest.Helper
{
    public class CostumerApi
    {
        public HttpClient Inıtal()
        {
            var client = new HttpClient();
            client.BaseAddress = new Uri("https://localhost:44381/");
            MediaTypeWithQualityHeaderValue contentType =new MediaTypeWithQualityHeaderValue("application/json");
            client.DefaultRequestHeaders.Accept.Add(contentType);

            return client;
        }
    }
}
