using FashionBoutik.Entities;
using System;
using System.Collections.Generic;

namespace FashionBoutik.Models
{
    /// <summary>
    /// Order is to create invoice with selected shopping Cart products
    /// </summary>
    public class OrderModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime CreatedDate { get; set; }

        /// <summary>
        /// TODO: 
        /// </summary>
        public int BuyerId { get; set; }

        public DateTimeOffset OrderDate { get; set; }

        public string Description { get; set; }

        /// <summary>
        /// Selected products
        /// </summary>
        public ICollection<CartItemModel> OrderItems { get; set; } = new List<CartItemModel>();

        public Address ShippingAddress { get; set; }

        public bool Delivered { get; set; } = false;

        public DateTime? DeliveryDate { get; set; }

        public Address BillingAddress { get; set; }

        public Payment Payment { get; set; }

        /// <summary>
        /// TODO:
        /// </summary>
        /// <returns></returns>
        public decimal Total
        {
            get
            {
                var total = 0m;
                foreach (var item in OrderItems)
                {
                    total += item.Product.PricePerUnit.Value * item.Count;
                }
                return total;
            }
        }
    }
}