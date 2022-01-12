using System;
using System.Collections.Generic;
using System.Text;
using AppVenta.Dominio;
using AppVenta.Dominio.Interfaces.Repositories;
using AppVenta.Application.Interfaces;

namespace AppVenta.Application.Services
{
    public class SaleServices : IServiceMovement<Sale, Guid>
    {
        IRepositoryMovement<Sale, Guid> repositorySale;
        IBaseRepository<Product, Guid> repository;
        IRepositoryDetail<SaleDetail, Guid> repositoryDetail;

        public SaleServices
            (
                IRepositoryMovement<Sale, Guid> _repositorySale,
                IBaseRepository<Product, Guid> _repository,
                IRepositoryDetail<SaleDetail, Guid> _repositoryDetail
            ) 
        {
            repositorySale = _repositorySale;
            repository = _repository;
            repositoryDetail = _repositoryDetail;
        }
        public Sale Add(Sale entity)
        {
            if(entity == null)
                throw new ArgumentNullException("The sale is required");
            var saleAdded = repositorySale.Add(entity);

            entity.saleDetails.ForEach(detail =>
            {
                var saleProduct = repository.SelectForId(detail.productId);
                if (saleProduct == null)
                    throw new NullReferenceException("The product to sell does not exist ");

                detail.unitCost = saleProduct.cost;
                detail.unitPrice = saleProduct.price;
                detail.quantitySold = detail.quantitySold;
                detail.subTotal = detail.unitPrice * detail.quantitySold; ;
                detail.tax = detail.subTotal * 15 / 100;
                detail.total = detail.subTotal + detail.tax;

                repositoryDetail.Add(detail);

                saleProduct.quantityInStock -= detail.quantitySold;
                repository.Edit(saleProduct);

                entity.subTotal = detail.subTotal;
                entity.tax = detail.tax;
                entity.total = detail.total;
            });

            repositorySale.AddAllChanges();
            return entity;
        }

        public void Cancel(Guid entityID)
        {
            repositorySale.Cancel(entityID);
            repository.AddAllChanges();
        }

        public Sale SelectForId(Guid entityID)
        {
            return repositorySale.SelectForId(entityID);
        }

        public List<Sale> ToList()
        {
            return repositorySale.ToList();
        }
    }
}
