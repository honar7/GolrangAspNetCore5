using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Threading.Tasks;

namespace Session12.ModelBindingTest.Controllers
{

    public class UpperCaseModelBinder : IModelBinder
    {
        public Task BindModelAsync(ModelBindingContext bindingContext)
        {
            if (bindingContext == null)
                throw new Exception();


            var modelName = bindingContext.ModelName;

            var valueProviderResult = bindingContext.ValueProvider.GetValue(modelName);

            if (valueProviderResult == ValueProviderResult.None)
            {
                return Task.CompletedTask;
            }

            bindingContext.ModelState.SetModelValue(modelName, valueProviderResult);

            var value = valueProviderResult.FirstValue;

            if (string.IsNullOrEmpty(value))
            {
                return Task.CompletedTask;
            }


            bindingContext.Result = ModelBindingResult.Success(value.ToUpper());
            return Task.CompletedTask;
        }
    }
    public class Person
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        [BindNever]
        public string NationalId { get; set; }
    }
    [Route("api/[controller]")]
    public class BindingController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get(int id,bool isvalid)
        {
            var isValid = ModelState.IsValid;
            return Ok($"The Value is {id}, is valid {isvalid}");
        }
        [HttpPost]
        public IActionResult Post([Bind("FirstName","LastName", Prefix ="person")]Person test)
        {
            return Ok($"FirstName:{test.FirstName}, LastName:{test.LastName}, Age: {test.Age}, nationalId:{test.NationalId}");
        }


        [HttpPost("age")]
        public IActionResult PostAge([Bind(Prefix = "person")] Person test)
        {
            return Ok($"FirstName:{test.FirstName}, LastName:{test.LastName}, Age: {test.Age}, nationalId:{test.NationalId}");
        }
        [HttpGet("ta")]
        public IActionResult GetAcceptValue([FromHeader]string accept)
        {
            return Ok($"Accept value  is {accept}");
        }
        [HttpGet("ToUpper")]
        public IActionResult ToUpper([ModelBinder(typeof(UpperCaseModelBinder))] string value)
        {
            return Ok(value);
        }
    }
}
