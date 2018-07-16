
using System.Collections.Generic;

namespace FashionBoutik.Entities
{
    public sealed class Retailer :  BaseEntity<int>
    {
        public string Description { get; set; }

        public string RetailerUrl { get; set; }

        public Address Address { get; set; }

        //TODO: status "Published", "RAW"

        public string Status { get; set; }

        //public Dictionary<string, string> Info { get; set; }
    }
}