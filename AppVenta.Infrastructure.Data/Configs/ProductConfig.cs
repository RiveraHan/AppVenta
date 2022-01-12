using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using AppVenta.Dominio;

namespace AppVenta.Infrastructure.Data.Configs
{
    class ProductConfig : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.ToTable("tblProducts");
            builder.HasKey(product => product.productId);

            builder.HasMany(product => product.saleDetails).WithOne(detail => detail.product);
        }
    }
}
