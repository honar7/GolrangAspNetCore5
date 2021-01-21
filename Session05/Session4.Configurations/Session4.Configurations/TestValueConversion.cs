using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Session4.Configurations
{
    public class TestValueConversion:BaseEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public ValueConversionInner ValueConversionInner { get; set; }
    }
    public class ValueConversionInner
    {
        public int TestInt01 { get; set; }
        public string TestString02 { get; set; }
    }
}
