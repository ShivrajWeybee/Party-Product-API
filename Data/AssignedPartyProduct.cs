using System;
using System.Collections.Generic;

#nullable disable

namespace PartyProductAPI.Data
{
    public partial class AssignedPartyProduct
    {
        public int Id { get; set; }
        public string PartyName { get; set; }
        public string ProductName { get; set; }
    }
}
