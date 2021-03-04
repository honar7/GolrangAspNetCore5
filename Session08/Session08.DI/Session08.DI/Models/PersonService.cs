using System;
using System.Linq;
using System.Threading.Tasks;

namespace Session08.DI.Models
{
    public class PersonService
    {
        private readonly IPersonRepository _personRepository;

        //public IPersonRepository PersonRepository { get; set; } = PersonRepositoryFactory.GetInstance();
        public PersonService(IPersonRepository PersonRepository)
        {
            _personRepository = PersonRepository;
        }
        public void SavePerson(Person person)
        {
            if(IsValid(person))
            {
                //IPersonRepository personFakeRepository = PersonRepositoryFactory.GetInstance();

                _personRepository.Save(person);
            }
        }

        private bool IsValid(Person person)
        {
            return true;
        }
    }
}
