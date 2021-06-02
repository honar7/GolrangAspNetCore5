using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Session13.API.TestInputModels;
namespace Session13.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MyApiForTestController : ControllerBase
    {

        [HttpPost]
        public ActionResult<string> Post([FromBody] TestInputModel testInputModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            string result = $"{testInputModel.FirstName}-{testInputModel.LastName}";
            return result;
        }




    }
}
