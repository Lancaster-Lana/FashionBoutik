using System;

namespace FashionBoutik.Entities
{
    public class Address : BaseEntity<int>
    {
        public String Street { get; set; }

        public String City { get; set; }

        public String State { get; set; }

        public String Country { get; set; }

        public String ZipCode { get; set; }
    }
}
