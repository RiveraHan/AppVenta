using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using AppVenta.Dominio;

namespace AppVenta.Infrastructure.Data.Configs
{
    class SaleDetailConfig : IEntityTypeConfiguration<SaleDetail>
    {
        public void Configure(EntityTypeBuilder<SaleDetail> builder)
        {
            builder.ToTable("tblSaleDetails");
            builder.HasKey(saleDetail => new { saleDetail.productId, saleDetail.saleId });

            builder.HasOne(detail => detail.product).WithMany(detail => detail.saleDetails);

            builder.HasOne(detail => detail.sale).WithMany(detail => detail.saleDetails);
        }
    }
}
