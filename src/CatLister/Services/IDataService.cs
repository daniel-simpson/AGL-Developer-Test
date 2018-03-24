using CatLister.Models;
using System.Collections.Generic;

namespace CatLister.Services
{
    public interface IDataService
    {
        IEnumerable<Person> GetPeopleAndPetData();
    }
}
