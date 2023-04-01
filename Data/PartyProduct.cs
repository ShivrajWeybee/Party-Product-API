using System;
using System.Collections.Generic;

#nullable disable

namespace PartyProductAPI.Data
{
    public partial class PartyProduct
    {
        public int PartyId { get; set; }
        public int ProductId { get; set; }
        public int Id { get; set; }

        public virtual Party Party { get; set; }
        public virtual Product Product { get; set; }
    }
}
