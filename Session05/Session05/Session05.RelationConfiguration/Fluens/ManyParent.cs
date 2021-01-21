using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Session05.RelationConfiguration.Fluens
{
    public class ManyLeft
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<ManyRight> Rights { get; set; }
        public List<RelationManyToMany> RelationManyToMany { get; set; }

    }
    public class RelationManyToMany
    {
        public int ManyLeftId { get; set; }
        public int ManyRightId { get; set; }
        public ManyRight ManyRight { get; set; }
        public ManyLeft ManyLeft { get; set; }
        public int SortOrder { get; set; }
    }
    public class ManyRight
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<ManyLeft> Lefts { get; set; }

        public List<RelationManyToMany> RelationManyToMany { get; set; }

    }
}
