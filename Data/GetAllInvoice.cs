using System;
using System.Collections.Generic;

#nullable disable

namespace PartyProductAPI.Data
{
    public partial class GetAllInvoice
    {
        public int InvoiceId { get; set; }
        public string PartyName { get; set; }
        public string ProductName { get; set; }
        public int Rate { get; set; }
        public int Quantity { get; set; }
        public int Total { get; set; }
    }
}
