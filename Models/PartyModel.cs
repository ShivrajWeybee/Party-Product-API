using System.ComponentModel.DataAnnotations;

namespace PartyProductAPI.Models
{
    public class PartyModel
    {
        public int PartyId { get; set; }

        [Required]
        public string PartyName { get; set; }
    }
}
