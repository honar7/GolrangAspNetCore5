using Microsoft.AspNetCore.Mvc;
using Session13.API.Controllers;
using Session13.API.TestInputModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Session13.ApiTest
{
    public class MyApiForTestControllerTest
    {
        [Fact]
        public void MyApiForTestController_ReturnsFullName()
        {
            var controller = new MyApiForTestController();
            var model = new TestInputModel
            {
                FirstName = "Alireza",
                LastName = "Oroumand"
            };
            ActionResult<string> result = controller.Post(model);
            Assert.NotNull(result);
        }

        [Fact]
        public void MyApiForTestController_ReturnsBadRequestWhenInvalid()
        {
            var controller = new MyApiForTestController();
            var model = new TestInputModel
            {
                FirstName = "",
                LastName = ""
            };

            controller.ModelState.AddModelError(nameof(model.FirstName), "FirstName Required");
            controller.ModelState.AddModelError(nameof(model.LastName), "LastName Required");
            
            ActionResult<string> result = controller.Post(model);

            Assert.IsType<BadRequestObjectResult>(result.Result);
        }
    }
}
