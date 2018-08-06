using System;
using FashionBoutik.Entities;

namespace FashionBoutik.Models
{

    public class CurrencyModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public DateTime CreatedDate { get; set; }

        //CurrencyEnum.Names
        public string CurrencyCode { get; set; }

        public string Symbol { get; set; }
        public decimal ConversionRate { get; set; }
        public Int16 CurrencyBase { get; set; }
        public byte Decimals { get; set; }

        public override string ToString()
        {
            return Symbol;
        }
    }
}