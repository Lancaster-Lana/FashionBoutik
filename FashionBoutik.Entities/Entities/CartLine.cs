using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FashionBoutik.Entities
{
    public class CartItem : BaseEntity<int>
    {

        [Required]
        public int ProductId { get; set; }

        [ForeignKey("ProductId")]
        public virtual Product Product { get; set; }

        //public decimal UnitPrice { get; private set; }

        [Required]
        public int Quantity { get; set; }
        //public int Units { get; private set; }
    }
}