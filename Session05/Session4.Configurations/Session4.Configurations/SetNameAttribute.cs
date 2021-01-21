using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Session4.Configurations
{
    [Table("MyTable",Schema ="stest")]
    public class SetNameAttribute
    {
        public int Id { get; set; }
        [Column(name:"column_Class_Name")]
        public string ClassName { get; set; }
    }
    public class SetNameFluent
    {
        public int Id { get; set; }
        public string ClassName { get; set; }
    }

}
