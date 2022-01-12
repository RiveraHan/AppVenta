using System;
using System.Collections.Generic;
using System.Text;
using AppVenta.Dominio;
using AppVenta.Dominio.Interfaces.Repositories;
using AppVenta.Application.Interfaces;

namespace AppVenta.Application.Services
{
    public class ProductService : IBaseServices<Product, Guid>
    {
        private readonly IBaseRepository<Product, Guid> repository;

        public ProductService(IBaseRepository<Product, Guid> baseRepository)
        {
            repository = baseRepository;
        }
        public Product Add(Product entity)
        {
            if (entity == null)
                throw new ArgumentNullException("The product is required");

            var resultProduct = repository.Add(entity);
            repository.AddAllChanges();
            return resultProduct;
        }

        public void Delete(Guid entityID)
        {
            if (entityID == null)
                throw new ArgumentNullException("Id product is required");
            repository.Delete(entityID);
            repository.AddAllChanges();
        }

        public void Edit(Product entity)
        {
            if (entity == null)
                throw new ArgumentNullException("The product is required");
            repository.Edit(entity);
            repository.AddAllChanges();
        }

        public Product SelectForId(Guid entityID)
        {
            if (entityID == null)
                throw new ArgumentNullException("Id product is required");

            return repository.SelectForId(entityID);
        }

        public List<Product> ToList()
        {
            return repository.ToList();
        }
    }
}
