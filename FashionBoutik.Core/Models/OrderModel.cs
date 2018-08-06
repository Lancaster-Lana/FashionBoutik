using System;
using System.Collections.Generic;
using System.Linq;

namespace FashionBoutik.Models
{

    public class OrderAddressModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime CreatedDate { get; set; }

        public AddressModel ShippingAddress { get; set; } = new AddressModel();
    }

    public class OrderPaymentModel
    {
        public string CardNumber { get; set; }

        public string CardExpiry { get; set; }

        public int CardSecurityCode { get; set; }

        public string AuthCode { get; set; }


        public decimal Total { get; set; } = 0;
    }

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

        public AddressModel ShippingAddress { get; set; }

        public bool Delivered { get; set; } = false;

        public DateTime? DeliveryDate { get; set; }

        public AddressModel BillingAddress { get; set; }

        public PaymentModel Payment { get; set; } = new PaymentModel(); //to init default payment

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

        //TODO:
        public string CurrencySymbol
        {
            get
            {
                return OrderItems.FirstOrDefault()?.Product?.PricePerUnit?.Currency?.CurrencyCode;
            }
        }
    }
}