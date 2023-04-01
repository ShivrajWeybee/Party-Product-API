using System;
using System.Collections.Generic;

#nullable disable

namespace PartyProductAPI.Data
{
    public partial class Product
    {
        public Product()
        {
            Invoices = new HashSet<Invoice>();
            PartyProducts = new HashSet<PartyProduct>();
            ProductRates = new HashSet<ProductRate>();
        }

        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public decimal? Rate { get; set; }

        public virtual ICollection<Invoice> Invoices { get; set; }
        public virtual ICollection<PartyProduct> PartyProducts { get; set; }
        public virtual ICollection<ProductRate> ProductRates { get; set; }
    }
}
