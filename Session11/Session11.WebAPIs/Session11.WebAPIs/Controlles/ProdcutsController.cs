using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
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
    public class ProdcutsController : ControllerBase
    {
        public ProdcutsController(Session11DbContext session11DbContext)
        {
            Session11DbContext = session11DbContext;
        }

        public Session11DbContext Session11DbContext { get; }

        [HttpGet]
        public List<Product> GetAll()
        {
            return Session11DbContext.Products.ToList();
        }
        [HttpGet("{id}")]

        public Product GetById(int id)
        {
            return Session11DbContext.Products.FirstOrDefault(c => c.ProductId == id);
        }
        //[HttpPost]

        //public IActionResult SaveProduct([FromBody] ProductInputDto product)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        Session11DbContext.Products.Add(product.ToProduct());
        //        var result = Session11DbContext.SaveChanges();
        //        return Created("api/Prodcuts/11",result);
        //    }
        //    return BadRequest(product);
        //}

        [HttpPost]

        public IActionResult SaveProduct(ProductInputDto product)
        {
            Session11DbContext.Products.Add(product.ToProduct());
            var result = Session11DbContext.SaveChanges();
            return Created("api/Prodcuts/11", result);
        }
        [HttpPatch]
        public IActionResult Patch(int productId, JsonPatchDocument<Product> patchDoc)
        {
            var product = Session11DbContext.Products.FirstOrDefault(c => c.ProductId == productId);
            if(product != null)
            {
                patchDoc.ApplyTo(product);
                Session11DbContext.SaveChanges();
            }
            return Ok();
        }
    }
}
