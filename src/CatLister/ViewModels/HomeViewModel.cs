using CatLister.Models;
using System.Collections.Generic;

namespace CatLister.ViewModels
{
    public class HomeViewModel
    {
        public IEnumerable<Pet> CatsWithMaleOwners { get; set; } = new List<Pet>();
        public IEnumerable<Pet> CatsWithFemaleOwners { get; set; } = new List<Pet>();
    }
}