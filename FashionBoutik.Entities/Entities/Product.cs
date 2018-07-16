using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace FashionBoutik.Entities
{
    /// <summary>
    /// Product details entity: 
    /// - product name
    /// - product category
    /// - brand, color, size, etc.
    /// </summary>
    public class Product : BaseEntity<int>
    {
        public string Description { get; set; }

        public int? CategoryId { get; set; }

        [ForeignKey("CategoryId")]
        public virtual Category Category { get; set; }

        /// <summary>
        /// TODO: Enum of brands
        /// </summary>
        public int? BrandId { get; set; }

        [ForeignKey("BrandId")]
        public virtual Brand Brand { get; set; }

        public int? ColorId { get; set; }

        [ForeignKey("ColorId")]
        public virtual ColorPallet Color { get; set; }

        //public int? PricePerUnitId { get; set; }

        /// <summary>
        /// Price on some date
        /// NOTE: the product may have different prices from day to day
        /// </summary>
        //[ForeignKey("PricePerUnitId")]
        public virtual Price PricePerUnit { get; set; }

        /// <summary>
        /// Available sizes
        /// </summary>
        public virtual ICollection<Size> Sizes { get; set; } = new List<Size>();

        /// <summary>
        /// CurrencyEnum
        /// </summary>
        //public Currency Currency { get; set; }

        /// <summary>
        /// History of product price changes 
        /// </summary>
        [NotMapped]
        public virtual Dictionary<DateTime, Price> PriceHistory{ get; set; } = new Dictionary<DateTime, Price>();

        [ForeignKey("ProductId")]
        public virtual ICollection<BinaryObject> Attachments { get; set; } = new List<BinaryObject>();
    }
}