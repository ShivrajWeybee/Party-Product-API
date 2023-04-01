using System;
using System.Collections.Generic;

#nullable disable

namespace PartyProductAPI.Data
{
    public partial class ProductRate
    {
        public int PrtId { get; set; }
        public int ProductId { get; set; }
        public decimal? Rate { get; set; }
        public DateTime? DateOfRate { get; set; }

        public virtual Product Product { get; set; }
    }
}
