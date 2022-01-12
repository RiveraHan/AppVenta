using System;
using System.Collections.Generic;
using System.Text;

namespace AppVenta.Dominio
{
    public class Sale
    {
        public Guid saleId { get; set; }
        public long salesNumber { get; set; }
        public DateTime date { get; set; }
        public string concept { get; set; }
        public decimal subTotal { get; set; }   
        public decimal tax { get; set; }
        public decimal total { get; set; }
        public List<SaleDetail> saleDetails { get; set; }
        public Boolean cancel { get; set; } = false;
    }
}
