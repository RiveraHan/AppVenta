using System;
using System.Collections.Generic;
using System.Text;
using AppVenta.Dominio;
using AppVenta.Dominio.Interfaces.Repositories;
using AppVenta.Infrastructure.Data.Contexts;

namespace AppVenta.Infrastructure.Data.Repositories
{
    public class SaleDetailRepository : IRepositoryDetail<SaleDetail, Guid>
    {
        private SaleContext db;

        public SaleDetailRepository(SaleContext _db)
        {
            db = _db;
        }
        public SaleDetail Add(SaleDetail entity)
        {
            db.Add(entity);
            return entity;
        }

        public void AddAllChanges()
        {
            db.SaveChanges();
        }
    }
}
