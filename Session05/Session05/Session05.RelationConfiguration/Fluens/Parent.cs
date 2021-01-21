using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Session05.RelationConfiguration.Fluens
{
    public class ParentFl
    {
        public int Id { get; set; }
        public List<ChidlFl> ChidlFls { get; set; }
    }
    public class ChidlFl
    {
        public int Id { get; set; }
        public ParentFl ParentFl { get; set; }

    }
}
