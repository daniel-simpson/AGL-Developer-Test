using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace CatLister.Services
{
    public class WebClientService : IWebClientService
    {
        HttpClient client;
        public WebClientService(string baseUri)
        {
            client = new HttpClient
            {
                BaseAddress = new Uri(baseUri)
            };
        }

        public async Task<string> GetAsync(string path)
        {
            return await client.GetStringAsync(path);
        }
    }
}