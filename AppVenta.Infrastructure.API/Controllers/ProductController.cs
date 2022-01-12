using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AppVenta.Dominio;
using AppVenta.Application.Services;
using AppVenta.Infrastructure.Data.Contexts;
using AppVenta.Infrastructure.Data.Repositories;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AppVenta.Infrastructure.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        ProductService CreateService()
        {
            SaleContext db = new SaleContext();
            ProductRepository repository = new ProductRepository(db);
            ProductService service = new ProductService(repository);
            return service;
        }
        // GET: api/<ProductController>
        [HttpGet]
        public ActionResult<List<Product>> Get()
        {
            var service = CreateService();
            return Ok(service.ToList());
        }

        // GET api/<ProductController>/5
        [HttpGet("{id}")]
        public ActionResult<Product> Get(Guid id)
        {
            var service = CreateService();
            return Ok(service.SelectForId(id));
        }

        // POST api/<ProductController>
        [HttpPost]
        public ActionResult Post([FromBody] Product product)
        {
            var service = CreateService();
            service.Add(product);
            return Ok("Product added successfull");
        }

        // PUT api/<ProductController>/5
        [HttpPut("{id}")]
        public ActionResult Put(Guid id, [FromBody] Product product)
        {
            var service = CreateService();
            product.productId = id;
            service.Edit(product);
            return Ok("Product edited successfull");
        }

        // DELETE api/<ProductController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(Guid id)
        {
            var service = CreateService();
            service.Delete(id);
            return Ok("Product deleted successfull");
        }
    }
}
