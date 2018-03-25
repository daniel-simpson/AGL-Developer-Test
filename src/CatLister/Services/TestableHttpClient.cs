using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace CatLister.Services
{
    public class TestableHttpClient : ITestableHttpClient
    {
        HttpClient client;
        public TestableHttpClient(string baseUri)
        {
            client = new HttpClient
            {
                BaseAddress = new Uri(baseUri),
            };
            client.DefaultRequestHeaders.Add("Accept", "application/json");
        }

        public async Task<string> GetAsync()
        {
            return await client.GetStringAsync("people.json");
        }
    }
}
