using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Session13.API.TestInputModels
{
    public class TestInputModel
    {
        [Required(ErrorMessage = "FirstName Required")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "LastName Required")]
        public string LastName { get; set; }
    }
    public interface ICustomeService
    {
    }

    public class RealService : ICustomeService
    {
    }

    public class FakeService : ICustomeService
    {
    }
}
