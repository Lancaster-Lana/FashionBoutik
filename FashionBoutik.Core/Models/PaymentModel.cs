using System.ComponentModel.DataAnnotations;

namespace FashionBoutik.Models
{
    public class PaymentModel
    {
        /// <summary>
        /// Shopping card number
        /// </summary>
        public string CardNumber { get; set; }

        public string CardExpiry { get; set; }

        public int CardSecurityCode { get; set; }

        public decimal Total { get; set; }

        public string AuthCode { get; set; }
    }
}