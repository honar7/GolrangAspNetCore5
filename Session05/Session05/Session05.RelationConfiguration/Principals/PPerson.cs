using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Session05.RelationConfiguration.Principals
{
    public class PPerson
    {
        public int Id { get; set; }
        public string NationalCode { get; set; }
    }

    public class PChild
    {
        public int Id { get; set; }
        public PPerson PPerson { get; set; }

    }
}
