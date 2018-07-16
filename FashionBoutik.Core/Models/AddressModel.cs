using System;

namespace FashionBoutik.Models
{
    public class AddressModel
    {
        public String Street { get; set; }

        public String City { get; set; }

        public String State { get; set; }

        public String Country { get; set; }

        public String ZipCode { get; set; }
        public object Name { get; internal set; }
        public object Id { get; internal set; }
        public object CreatedDate { get; internal set; }
    }
}
