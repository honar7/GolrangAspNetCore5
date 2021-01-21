using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Session05.RelationConfiguration.Attibutes
{
    public class ParentAttr
    {
        public int Id { get; set; }
        public List<ChildAttr> ChildAttrs { get; set; }
    }
    public class ChildAttr
    {
        public int Id { get; set; }

        [ForeignKey("ParentIdFk")]
        public int ParentIdFk { get; set; }

        public ParentAttr Parent { get; set; }
    }


    public class PersonAttr
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        [InverseProperty("Writer")]
        public List<BookAttr> AsWriter { get; set; }
        [InverseProperty("Editor")]
        public List<BookAttr> AsEditor { get; set; }
    }

    public class BookAttr
    {
        public int Id { get; set; }
        public string BookName { get; set; }
        public PersonAttr Writer { get; set; }
        public PersonAttr Editor { get; set; }
    }
}
