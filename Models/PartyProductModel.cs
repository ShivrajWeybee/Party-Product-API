using System.ComponentModel.DataAnnotations;

namespace PartyProductAPI.Models
{
    public class PartyProductModel
    {
        public int Id { get; set; }

        [Required]
        public int PartyId { get; set; }

        [Required]
        public int ProductId { get; set; }

    }
}
