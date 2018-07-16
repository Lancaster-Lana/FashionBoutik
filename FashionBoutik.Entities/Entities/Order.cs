using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FashionBoutik.Entities
{
    public class Order : BaseEntity<int>
    {
        /// <summary>
        /// Person or company
        /// </summary>
        public int BuyerId { get; set; }

        public DateTimeOffset OrderDate { get; set; } = DateTimeOffset.Now;

        public string Description { get; set; }

        /// <summary>
        /// Selected products
        /// </summary>
        public virtual ICollection<CartItem> OrderItems { get; set; } = new List<CartItem>();


        //[Required]
        public int? ShippingAddressId { get; set; }

        [ForeignKey("ShippingAddressId")]
        public virtual Address ShippingAddress { get; set; }

        public bool Delivered { get; set; } = false;

        public DateTime? DeliveryDate { get; set; }

        public int? BillingAddressId { get; set; }

        [ForeignKey("BillingAddressId")]
        public virtual Address BillingAddress { get; set; }

        [Required]
        public virtual Payment Payment { get; set; }

        /// <summary>
        /// TODO:
        /// </summary>
        /// <returns></returns>
        public decimal Total { get; set; }
        //{
        //    var total = 0m;
        //    foreach (var item in OrderItems)
        //    {
        //        total += item.Product.PricePerUnit.Value * item.Quantity;
        //    }
        //    return total;
        //}
    }
}