using System.ComponentModel.DataAnnotations;

namespace FashionBoutik.Entities
{
    /// <summary>
    /// Payment options : card and sum purchase
    /// </summary>
    public class Payment : BaseEntity<int>
    {
        /// <summary>
        /// Shopping card number
        /// </summary>
        [Required]
        public string CardNumber { get; set; }

        [Required]
        public string CardExpiry { get; set; }

        [Required]
        public int CardSecurityCode { get; set; }

        //[BindNever]
        public decimal Total { get; set; }

        //[BindNever]
        public string AuthCode { get; set; }
    }
}