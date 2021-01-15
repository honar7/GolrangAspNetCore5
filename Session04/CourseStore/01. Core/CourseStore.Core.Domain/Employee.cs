using System.Collections.Generic;

namespace CourseStore.Core.Domain
{
    public class Employee
    {
        public int EmployeeId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public List<Employee> Employees { get; set; }
    }
}
