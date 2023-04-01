namespace PartyProductAPI.Models
{
    public class InvoiceModel
    {
        public int InvoiceId { get; set; }
        public int PartyId { get; set; }
        public int ProductId { get; set; }
        public int Rate { get; set; }
        public int Quantity { get; set; }
        public int Total { get; set; }
    }
}
