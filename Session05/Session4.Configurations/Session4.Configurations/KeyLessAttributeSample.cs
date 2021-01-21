using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Session4.Configurations
{
    [Keyless]
    public class KeyLessAttributeSample
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }

    public class KeyLessFluentSample
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
