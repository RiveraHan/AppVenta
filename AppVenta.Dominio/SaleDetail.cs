using System;
using System.Collections.Generic;
using System.Text;

namespace AppVenta.Dominio
{
    public class SaleDetail
    {
        public Guid productId { get; set; }
        public Guid saleId { get; set; }
        public decimal unitCost { get; set; }
        public decimal unitPrice { get; set; }
        public int quantitySold { get; set; }
        public decimal subTotal { get; set; }
        public decimal tax { get; set; }
        public decimal total { get; set; }
        public Product product { get; set; }
        public Sale sale { get; set; }

    }
}
