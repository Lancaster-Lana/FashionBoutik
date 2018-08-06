using System;
using System.Text;

namespace FashionBoutik.Models
{
    public class AddressModel
    {
        public int Id { get; internal set; }

        public string Name { get; set; }

        public String ZipCode { get; set; }

        public String Country { get; set; }

        public String City { get; set; }

        public String State { get; set; }

        public String Street { get; set; }


        public DateTime CreatedDate { get; set; }

        public override string ToString()
        {
            var addressStr = new StringBuilder();

            addressStr.Append(City + ", ");
            addressStr.Append(Country + ", ");
            addressStr.Append(ZipCode);
            if (!string.IsNullOrWhiteSpace(State))
                addressStr.AppendLine(State + ",");
            if (!string.IsNullOrWhiteSpace(Street))
                addressStr.AppendLine(Street + " Str.");
            return addressStr.ToString();
        }
    }
}
