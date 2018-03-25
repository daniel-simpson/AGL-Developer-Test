using CatLister.Models;
using CatLister.Services;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace CatLister.Controllers
{
    public class PersonApiController : ApiController
    {
        private IWebClientService _webClientService;

        public PersonApiController(IWebClientService webClientService)
        {
            _webClientService = webClientService;
        }

        public async Task<IEnumerable<Person>> GetAsync()
        {
            var responseText = await _webClientService.GetAsync("/people.json");

            var people = JsonConvert.DeserializeObject<IEnumerable<Person>>(responseText);
            return people;
        }
    }
}
