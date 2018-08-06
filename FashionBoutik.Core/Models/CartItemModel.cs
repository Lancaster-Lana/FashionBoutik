using System;
using System.Collections.Generic;

namespace FashionBoutik.Models
{
    /// <summary>
    /// Draft backer with info about buyer and selected products
    /// </summary>
    public class CartModel
    {
        /// <summary>
        /// Temporary cart (for cached products)
        /// </summary>
        public int Id { get; set; }

        public int BuyerId { get; set; }

        /// <summary>
        /// Selected products in backet
        /// </summary>
        public List<CartItemModel> CartItems { get; set; } = new List<CartItemModel>();

        //public decimal Total()
        //{
        //    return Math.Round(Items.Sum(x => x.Product.PricePerUnit * x.Quantity), 2);
        //}
    }

    /// <summary>
    /// Selected products (and its amount=count)
    /// </summary>

    public class CartItemModel
    {
        /// <summary>
        /// 
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Product name
        /// </summary>
        public string Name { get; set; }

        public DateTime CreatedDate { get; set; }

        public int Count { get; set; }

        public ProductModel Product { get; set; }
    }
}
