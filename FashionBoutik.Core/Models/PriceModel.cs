using System;
namespace FashionBoutik.Models
{

    public class PriceModel 
    {
        /// <summary>
        /// It is Product Id
        /// </summary>
        public int Id { get; set; }

        //public string Name { get; set; }

        public DateTime PriceDate { get; set; }

        public decimal Value { get; set; }

        public CurrencyModel Currency { get; set; }
    }
}