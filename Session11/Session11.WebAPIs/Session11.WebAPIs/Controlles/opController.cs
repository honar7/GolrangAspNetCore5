using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Session11.WebAPIs.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Session11.WebAPIs.Controlles
{
    [Route("api/[controller]")]
    [ApiController]
    public class opController : ControllerBase
    {

        public opController(Session11DbContext session11DbContext)
        {
            Session11DbContext = session11DbContext;
        }

        public Session11DbContext Session11DbContext { get; }
        [HttpGet("StringVal")]
        public string StringVal()
        {
            return "String Value";
        }


        [HttpGet("JsonValue")]
        public int JsonVal()
        {
            return 1;
        }


        [HttpGet]
        [Produces("application/json")]

        public ProductInputDto GetP() => new ProductInputDto
        {
            Price = 100,
            Name = "Test"
        };




        //[HttpGet("object/{format?}")]
        //[FormatFilter]
        ////[Produces("application/json", "application/xml")]
        //public async Task<ProductInputDto> GetObject()
        //{           
        //    return new ProductInputDto()
        //    {
        //        Name = "test",
        //        Price = 1000,
        //    };
        //}


        [HttpPost]
        [Consumes("application/json")]
        public IActionResult SaveProduct(ProductInputDto product)
        {
            Session11DbContext.Products.Add(product.ToProduct());
            var result = Session11DbContext.SaveChanges();
            return Created("api/Prodcuts/11", result);
        }

    }
}
