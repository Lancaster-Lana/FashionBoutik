using System;

namespace FashionBoutik.Entities
{
    public class Currency : BaseEntity<int>
    {
        /// <summary>
        /// 2-3 Letters
        /// </summary>
        public string CurrencyCode { get; set; }

        public string Symbol { get; set; }

        public decimal ConversionRate { get; set; }
        public Int16 CurrencyBase { get; set; }
        public byte Decimals { get; set; }
    }
}