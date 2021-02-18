using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AdvancedConfigurations
{
    public class BankAccout
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Value { get; set; }
        [Timestamp]
        public byte[] Version { get; set; }

    }
    public class Person
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public string FavoritColor { get; set; } 
        //[DatabaseGenerated(DatabaseGeneratedOption.)]
        public string FullName { get; private set; }
        public int SequenceValue { get; set; }
        //[NotMapped]
        //public string FullName => $"{FirstName}, {LastName}";
    }
}
