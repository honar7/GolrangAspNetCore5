using System.Collections.Generic;

namespace Session08.DI.Models
{

    public class PersonFakeRepository : IPersonRepository
    {
        private static List<Person> _people = new List<Person>();
        private readonly bool _useCache;
        private readonly int _age;

        public PersonFakeRepository()
        {

        }
        public void Save(Person person)
        {
            person.Id = _people.Count + 1;
            _people.Add(person);
        }
    }

    public class PersonEfRepository : IPersonRepository
    {
        public void Save(Person person)
        {
            throw new System.NotImplementedException();
        }
    }
}
