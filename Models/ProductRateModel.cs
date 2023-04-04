using System;
using System.ComponentModel.DataAnnotations;

namespace PartyProductAPI.Models
{
    public class ProductRateModel
    {
        public int PrtId { get; set; }

        [Required]
        public int ProductID { get; set; }

        [Required]
        public decimal? Rate { get; set; }
        public DateTime? DateOfRate { get; set; }
    }
}
