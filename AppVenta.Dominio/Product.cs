using System;
using System.Collections.Generic;
using System.Text;

namespace AppVenta.Dominio
{
    public class Product
    {
        public Guid productId { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public decimal cost { get; set; }
        public decimal price { get; set; }
        public int quantityInStock { get; set; }
        public List<SaleDetail> saleDetails { get; set; }
    }
}
