using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Session4.Configurations
{
    public class BackingField
    {
        public int Id { get; set; }

        private string mytestBackingFieldFirstName;
        public string FirstName { get; private set; }
        public void SetFirstName(string firstName)
        {
            mytestBackingFieldFirstName = firstName;
        }
        public string LastName { get; set; }
    }
}
