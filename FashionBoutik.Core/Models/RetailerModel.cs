using System;

namespace FashionBoutik.Models {

    public class RetailerModel {

        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public AddressModel Address { get; set; }

        public string RetailerUrl { get; set; }

        public string Status { get; set; }
        public DateTime CreatedDate { get; set; }

        //public Dictionary<string, string> Info { get; set; }
    }
}