using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Session4.Configurations
{
  
    public class PkTestAttribute
    {
        //[Key]
        [Column(Order = 2)]
        public int Pk01 { get; set; }
        //[Key]
        [Column(Order = 1)]
        public int Pk02 { get; set; }
    }
}
