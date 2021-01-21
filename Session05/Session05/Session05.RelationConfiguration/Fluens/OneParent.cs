using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Session05.RelationConfiguration.Fluens
{
    public class OneParent
    {
        public int Id { get; set; }
        public string ParentName { get; set; }
        public OneChild Child { get; set; }
        public List<ManyChild> ManyChildren { get; set; }
    }
    public class ManyChild
    {
        public int Id { get; set; }
        public string ChildName { get; set; }
    }
    public class OneChild
    {
        public int Id { get; set; }
        public string ChildName { get; set; }
    }
}
