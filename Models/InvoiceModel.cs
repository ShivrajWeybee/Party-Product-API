using System.ComponentModel.DataAnnotations;

namespace PartyProductAPI.Models
{
    public class InvoiceModel
    {
        public int InvoiceId { get; set; }
        [Required]
        [Display(Name = "Party")]
        public int PartyId { get; set; }
        [Required]
        [Display(Name = "Product")]
        public int ProductId { get; set; }
        [Required]
        public int Rate { get; set; }
        [Required]
        public int Quantity { get; set; }
        public int Total { get; set; }
    }
}
