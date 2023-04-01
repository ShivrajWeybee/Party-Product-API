using System;
using System.Collections.Generic;

#nullable disable

namespace PartyProductAPI.Data
{
    public partial class Party
    {
        public Party()
        {
            Invoices = new HashSet<Invoice>();
            PartyProducts = new HashSet<PartyProduct>();
        }

        public int PartyId { get; set; }
        public string PartyName { get; set; }

        public virtual ICollection<Invoice> Invoices { get; set; }
        public virtual ICollection<PartyProduct> PartyProducts { get; set; }
    }
}
