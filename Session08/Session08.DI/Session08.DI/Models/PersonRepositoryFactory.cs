using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Session08.DI.Models
{
    public class PersonRepositoryFactory
    {
        public static IPersonRepository GetInstance()
        {
            if(DateTime.Now.Hour> 12)
                return new PersonFakeRepository();
            return new PersonEfRepository();
        }
    }
}
