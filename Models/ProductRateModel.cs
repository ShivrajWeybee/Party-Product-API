using System;

namespace PartyProductAPI.Models
{
    public class ProductRateModel
    {
        public int PrtId { get; set; }
        public int ProductID { get; set; }
        public decimal? Rate { get; set; }
        public DateTime? DateOfRate { get; set; }
    }
}
