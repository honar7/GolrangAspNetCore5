using System.ComponentModel.DataAnnotations.Schema;

namespace Session4.Configurations
{
    [NotMapped]
    public class FirstNotMappedAttribute
    {
        public string TeacherName { get; set; }
    }
}
