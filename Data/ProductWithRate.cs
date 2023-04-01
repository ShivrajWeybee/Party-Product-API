using System;
using System.Collections.Generic;

#nullable disable

namespace PartyProductAPI.Data
{
    public partial class ProductWithRate
    {
        public int PrtId { get; set; }
        public string ProductName { get; set; }
        public decimal? Rate { get; set; }
        public DateTime? DateOfRate { get; set; }
    }
}
