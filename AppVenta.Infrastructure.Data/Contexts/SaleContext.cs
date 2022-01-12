using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using AppVenta.Infrastructure;
using AppVenta.Dominio;
using AppVenta.Infrastructure.Data.Configs;

namespace AppVenta.Infrastructure.Data.Contexts
{
    public class SaleContext : DbContext
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<Sale> Sales { get; set; }
        public DbSet<SaleDetail> SaleDetails { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=localhost\SQLEXPRESS;Database=AppVentas;Trusted_Connection=True;");
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.ApplyConfiguration(new ProductConfig());
            builder.ApplyConfiguration(new SaleConfig());
            builder.ApplyConfiguration(new SaleDetailConfig());
        }
    }
}
