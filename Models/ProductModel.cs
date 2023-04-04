using System.ComponentModel.DataAnnotations;

namespace PartyProductAPI.Models
{
    public class ProductModel
    {
        public int ProductId { get; set; }

        [Required]
        public string ProductName { get; set; }
    }
}
