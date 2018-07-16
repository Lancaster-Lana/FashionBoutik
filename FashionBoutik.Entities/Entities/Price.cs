using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FashionBoutik.Entities
{
    /// <summary>
    /// Product current price
    /// </summary>
    public class Price //: BaseEntity<int>
    {
        public DateTime PriceDate { get; set; }

        [Key]
        public int Id { get; set; }


        public int ProductId { get; set; }

        /// <summary>
        /// Price on some date
        /// NOTE: the product may have different prices from day to day
        /// </summary>
        [ForeignKey("ProductId")]

        public virtual Product Product { get; set; }

        public decimal Value { get; set; }

        public int CurrencyId { get; set; } = (int)CurrencyEnum.USD; // Default is dollar

        //CurrencyEnum
        [ForeignKey("CurrencyId")]
        public virtual Currency Currency { get; set; }
    }
}