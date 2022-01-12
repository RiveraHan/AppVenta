using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using AppVenta.Dominio;

namespace AppVenta.Infrastructure.Data.Configs
{
    class SaleConfig : IEntityTypeConfiguration<Sale>
    {
        public void Configure(EntityTypeBuilder<Sale> builder)
        {
            builder.ToTable("tblSales");
            builder.HasKey(sale => sale.saleId);

            builder.HasMany(sale => sale.saleDetails).WithOne(detail => detail.sale);
        }
    }
}
