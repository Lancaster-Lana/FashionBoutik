using FashionBoutik.Entities;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace FashionBoutik.Models
{
    public class CustomerModel
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public string Description { get; set; }

        //[Required]
        //public UserViewModel User{ get; set; }

        /// <summary>
        /// TODO:
        /// </summary>
        public string Status { get; set; }

        public string Address { get; set; }

        [Required]
        public string GiftCards { get; set; }

    }
}
