using System.Collections.Generic;

namespace CatLister.Models
{
    public class Person
    {
        public string Name { get; set; }
        public Gender Gender { get; set; }
        public int Age { get; set; }
        public IEnumerable<Pet> Pets { get; set; }
    }
}