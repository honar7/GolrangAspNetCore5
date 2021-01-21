using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Session4.Configurations
{
    public class FirstEntityAttribute : BaseEntity
    {
        [Required]
        [MaxLength(50)]
        public string FirstName { get; set; }
        [Required]
        [MaxLength(50)]
        
        public string LastName { get; set; }
        [NotMapped]
        public string FullName { get; set; }
        [Column(TypeName="Date")]
        public DateTime BirthDate { get; set; }
        public FirstNotMappedAttribute FirstNotMappedAttribute { get; set; }
    }
}
