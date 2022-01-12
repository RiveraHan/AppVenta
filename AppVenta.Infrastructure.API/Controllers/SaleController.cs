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
    public class SaleController : ControllerBase
    {
        SaleServices CreateService()
        {
            SaleContext db = new SaleContext();
            SaleRepository saleRepository = new SaleRepository(db);
            ProductRepository productRepository = new ProductRepository(db);
            SaleDetailRepository saleDetailRepository = new SaleDetailRepository(db);
            SaleServices services = new SaleServices(saleRepository, productRepository, saleDetailRepository);
            return services;

        }
        // GET: api/<SaleController>
        [HttpGet]
        public ActionResult<List<Sale>> Get()
        {
            var service = CreateService();
            return Ok(service.ToList());
        }

        // GET api/<SaleController>/5
        [HttpGet("{id}")]
        public ActionResult<Sale> Get(Guid id)
        {
            var service = CreateService();
            return Ok(service.SelectForId(id));
        }

        // POST api/<SaleController>
        [HttpPost]
        public ActionResult<Sale> Post([FromBody] Sale sale)
        {
            var service = CreateService();
            service.Add(sale);
            return Ok("Sale added successfull");
        }

        // DELETE api/<SaleController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(Guid id)
        {
            var service = CreateService();
            service.Cancel(id);
            return Ok("Sale deleted successfull");
        }
    }
}
