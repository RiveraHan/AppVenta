using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AppVenta.Dominio;
using AppVenta.Dominio.Interfaces.Repositories;
using AppVenta.Infrastructure.Data.Contexts;

namespace AppVenta.Infrastructure.Data.Repositories
{
    public class ProductRepository : IBaseRepository<Product, Guid>
    {
        private SaleContext db;
        public ProductRepository(SaleContext _db)
        {
            db = _db;
        }
        public Product Add(Product entity)
        {
            entity.productId = Guid.NewGuid();
            db.Products.Add(entity);
            return entity;

        }

        public void AddAllChanges()
        {
            db.SaveChanges();
        }

        public void Delete(Guid entityID)
        {
            var productSelect = db.Products.Where(product => product.productId == entityID).FirstOrDefault();
            if(productSelect != null)
            {
                db.Products.Remove(productSelect);
            }
        }

        public void Edit(Product entity)
        {
            var productSelect = db.Products.Where(product => product.productId == entity.productId).FirstOrDefault();
            if(productSelect != null)
            {
                productSelect.name = entity.name;
                productSelect.price = entity.price;
                productSelect.description = entity.description;
                productSelect.cost = entity.cost;
                productSelect.quantityInStock = entity.quantityInStock;

                db.Entry(productSelect).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            }
        }

        public Product SelectForId(Guid entityID)
        {
            var productSelect = db.Products.Where(product => product.productId == entityID).FirstOrDefault();
            return productSelect; 
        }

        public List<Product> ToList()
        {
            return db.Products.ToList();
        }
    }
}
