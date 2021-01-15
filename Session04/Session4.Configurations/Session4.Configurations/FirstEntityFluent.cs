using System;

namespace Session4.Configurations
{
    public class FirstEntityFluent : BaseEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FullName { get; set; }
     public DateTime BirthDate { get; set; }
        public FirstNotMappedFluent FirstNotMappedFluent { get; set; }
    }
}
