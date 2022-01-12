using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using AppVenta.Dominio;
using AppVenta.Dominio.Interfaces.Repositories;
using AppVenta.Infrastructure.Data.Contexts;

namespace AppVenta.Infrastructure.Data.Repositories
{
    public class SaleRepository : IRepositoryMovement<Sale, Guid>
    {
        private SaleContext db;
        public SaleRepository(SaleContext _db)
        {
            db = _db;
        }
        public Sale Add(Sale entity)
        {
            entity.saleId = Guid.NewGuid();
            db.Sales.Add(entity);
            return entity;
        }

        public void AddAllChanges()
        {
            db.SaveChanges();
        }

        public void Cancel(Guid entityID)
        {
            var saleSelect = db.Sales.Where(sale => sale.saleId == entityID).FirstOrDefault();

            if (saleSelect == null)
                throw new NullReferenceException("You can't with a sale that doesn't exist");
            saleSelect.cancel = true;

            db.Entry(saleSelect).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
        }

        public Sale SelectForId(Guid entityID)
        {
            var saleSelect = db.Sales.Where(sale => sale.saleId == entityID).FirstOrDefault();
            return saleSelect;
        }

        public List<Sale> ToList()
        {
            return db.Sales.ToList();
        }
    }
}
