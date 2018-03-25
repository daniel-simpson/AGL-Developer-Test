using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using CatLister.Models;
using Newtonsoft.Json;
using CatLister.ViewModels;
using System.Linq;

namespace CatLister.Services
{
    public class PersonService : IPersonService
    {
        private ITestableHttpClient _client;

        public PersonService(ITestableHttpClient client)
        {
            _client = client;
        }
        
        public async Task<HomeViewModel> GetCatsByOwnerGenderAsync()
        {
            var responseText = await _client.GetAsync();
            var people = JsonConvert.DeserializeObject<IEnumerable<Person>>(responseText);

            var model = new HomeViewModel
            {
                CatsWithMaleOwners = people
                    .Where(person => person.Gender == Gender.Male && person.Pets != null && person.Pets.Any(pet => pet.Type == AnimalType.Cat))
                    .SelectMany(owner => owner.Pets.Where(pet => pet.Type == AnimalType.Cat))
                    .OrderBy(pet => pet.Name),

                CatsWithFemaleOwners = people
                    .Where(person => person.Gender == Gender.Female && person.Pets != null && person.Pets.Any(pet => pet.Type == AnimalType.Cat))
                    .SelectMany(owner => owner.Pets.Where(pet => pet.Type == AnimalType.Cat))
                    .OrderBy(pet => pet.Name),
            };

            return model;
        }
    }
}