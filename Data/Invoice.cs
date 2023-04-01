using System;
using System.Collections.Generic;

#nullable disable

namespace PartyProductAPI.Data
{
    public partial class Invoice
    {
        public int InvoiceId { get; set; }
        public int PartyId { get; set; }
        public int ProductId { get; set; }
        public int Rate { get; set; }
        public int Quantity { get; set; }
        public int Total { get; set; }

        public virtual Party Party { get; set; }
        public virtual Product Product { get; set; }
    }
}
